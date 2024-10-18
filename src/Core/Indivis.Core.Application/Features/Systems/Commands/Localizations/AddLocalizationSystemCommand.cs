using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Commands.Localizations
{
    public class AddLocalizationSystemCommand : IRequest<IResultDataControl<ReadLocalizationDto>>
    {
        public WriteLocalizationDto Localization{ get; set; }
    }

    public class AddLocalizationSystemCommandHandler :
        IRequestHandler<AddLocalizationSystemCommand, IResultDataControl<ReadLocalizationDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AddLocalizationSystemCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResultDataControl<ReadLocalizationDto>> Handle(AddLocalizationSystemCommand request, CancellationToken cancellationToken)
        {

            IResultDataControl<ReadLocalizationDto> model = new ResultDataControl<ReadLocalizationDto>();
            try
            {
                Localization localizaton = this._mapper.Map<Localization>(request.Localization);

                
                if (this._applicationDbContext.Localization.Any(x=>x.Key == request.Localization.Key))
                {
                    return model.SuccessSetData(this._mapper.Map<ReadLocalizationDto>(this._applicationDbContext.Localization.FirstOrDefaultAsync(x => x.Key == request.Localization.Key)));
                }

                EntityEntry<Localization> addResult = this._applicationDbContext.Localization.Add(localizaton);

                int saveChanges = await this._applicationDbContext.SaveChangesAsync();

                if (saveChanges <= 0)
                {
                    throw new Exception($"Localizaton kayıt edilemedi ! {request.Localization.Key}");
                }

                model.SuccessSetData(this._mapper.Map<ReadLocalizationDto>(localizaton));
                addResult.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
