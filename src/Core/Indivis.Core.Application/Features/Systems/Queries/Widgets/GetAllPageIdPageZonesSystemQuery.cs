using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Queries.Widgets
{
    public class GetAllPageIdPageZonesSystemQuery : IRequest<IResultDataControl<List<ReadPageZoneDto>>>
    {
        public Guid PageId { get; set; }
    }


    public class GetAllPageIdPageZonesHandler : IRequestHandler<GetAllPageIdPageZonesSystemQuery, IResultDataControl<List<ReadPageZoneDto>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllPageIdPageZonesHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadPageZoneDto>>> Handle(GetAllPageIdPageZonesSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadPageZoneDto>> model = new ResultDataControl<List<ReadPageZoneDto>>();
            model.SetData(new List<ReadPageZoneDto>());

            try
            {
                List<PageZone> pageZones = await this._applicationDbContext.PageZones.Where(x => x.PageId == request.PageId)
                .Include(x => x.PageWidgets)
                .ThenInclude(x => x.Widget)
                .ThenInclude(x => x.WidgetTemplates)
                .ThenInclude(x => x.WidgetService)
                .Include(x => x.PageWidgets)
                .ThenInclude(x => x.PageWidgetSetting)
                .ToListAsync();

                model.SuccessSetData(this._mapper.Map<List<ReadPageZoneDto>>(pageZones));
            }
            catch (Exception exception)
            {
                model.Fail(exception);
            }
            

            return model;
        }
    }
}
