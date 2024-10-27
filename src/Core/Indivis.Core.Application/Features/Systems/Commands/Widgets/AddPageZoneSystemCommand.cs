using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Commands.Widgets
{
    public class AddPageZoneSystemCommand : IRequest<IResultDataControl<ReadPageZoneDto>>
    {
        public WritePageZoneDto PageZone { get; set; }
    }

    public class AddPageZoneSystemHandlerCommand : IRequestHandler<AddPageZoneSystemCommand, IResultDataControl<ReadPageZoneDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AddPageZoneSystemHandlerCommand(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadPageZoneDto>> Handle(AddPageZoneSystemCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadPageZoneDto> model = new ResultDataControl<ReadPageZoneDto>();

            try
            {
                if (this._applicationDbContext.PageZones.Any(x=>x.PageId == request.PageZone.PageId && x.Key == request.PageZone.Key && x.State == (int)StateEnum.Online))
                {
                    throw new Exception($"{request.PageZone.Key} eklenmek istenin zone alanı zaten mevcut");
                }

                PageZone pageZone = this._mapper.Map<PageZone>(request.PageZone);

                EntityEntry<PageZone> entityEntry = await this._applicationDbContext.PageZones.AddAsync(pageZone);

                int result = await this._applicationDbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    throw new Exception($"{typeof(AddPageZoneSystemHandlerCommand)} Teknik bir problem yaşandı, lütfen daha sonra tekrar deneyiniz !");
                }

                model.SuccessSetData(this._mapper.Map<ReadPageZoneDto>(entityEntry.Entity));
                entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
