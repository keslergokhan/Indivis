using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features;
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
    public class GetAllWidgetsSystemQuery :
        IRequest<IResultDataControl<List<ReadWidgetDto>>>,
        IOnlineAndOfflineFilterQuery,
        IStateFilterQuery,
        ILanguageFilterQuery
    {
        public bool OnlineAndOffline { get; set; }
        public StateEnum State { get; set; }
        public Guid LanguageId { get; set; }
    }


    public class GetAllWidgetsSystemQueryHandler : IRequestHandler<GetAllWidgetsSystemQuery, IResultDataControl<List<ReadWidgetDto>>>
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllWidgetsSystemQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadWidgetDto>>> Handle(GetAllWidgetsSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadWidgetDto>> result = new ResultDataControl<List<ReadWidgetDto>>();

            try
            {
                IQueryable<Widget> widgetQuery = this._applicationDbContext.Widgets.Where(x=>x.LanguageId == request.LanguageId).Include(x=>x.WidgetTemplates).AsNoTrackingWithIdentityResolution().AsQueryable();

                if (request.OnlineAndOffline)
                {
                    widgetQuery = widgetQuery.Where(x => x.State == (byte)StateEnum.Online || x.State == (byte)StateEnum.Offline).AsQueryable();
                }
                else
                {
                    widgetQuery = widgetQuery.Where(x => x.State == (byte)request.State).AsQueryable();
                }

                List<Widget> widgets = widgetQuery.ToList();


                result.SuccessSetData(this._mapper.Map<List<ReadWidgetDto>>(widgets));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
