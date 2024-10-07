using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
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
    public class GeyByZoneIdAllPageWidgetSystemQuery : IRequest<IResultDataControl<List<ReadPageWidgetDto>>>
    {
        public Guid PageZoneId { get; set; }
    }

    public class GeyByZoneIdAllPageWidgetSystemQueryHandler : IRequestHandler<GeyByZoneIdAllPageWidgetSystemQuery, IResultDataControl<List<ReadPageWidgetDto>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GeyByZoneIdAllPageWidgetSystemQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadPageWidgetDto>>> Handle(GeyByZoneIdAllPageWidgetSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadPageWidgetDto>> model = new ResultDataControl<List<ReadPageWidgetDto>>();

            try
            {
                List<PageWidget> pageWidgetList = await this._applicationDbContext.PageWidgets
                    .Where(x => x.PageZoneId == request.PageZoneId && x.State == (int)StateEnum.Online)
                    .Include(x=>x.PageWidgetSetting)
                    .Include(x=>x.Widget)
                    .OrderBy(x=>x.PageWidgetSetting.Order)
                    .ToListAsync();

                model.SuccessSetData(this._mapper.Map<List<ReadPageWidgetDto>>(pageWidgetList));

            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
