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
    public class GetAllWidgetFormAndWidgetFormInputQuery :
        IRequest<IResultDataControl<List<ReadWidgetFormDto>>>,
        IOnlineAndOfflineFilterQuery,
        IStateFilterQuery,
        ILanguageFilterQuery
    {
        public bool OnlineAndOffline { get; set; }
        public StateEnum State { get; set; }
        public Guid LanguageId { get; set; }
        public Guid WidgetTemplateId { get; set; }
        public Guid WidgetId { get; set; }
    }

    public class GetAllWidgetFormAndWidgetFormInputQueryHandler :
        IRequestHandler<GetAllWidgetFormAndWidgetFormInputQuery, IResultDataControl<List<ReadWidgetFormDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;
        public GetAllWidgetFormAndWidgetFormInputQueryHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResultDataControl<List<ReadWidgetFormDto>>> Handle(GetAllWidgetFormAndWidgetFormInputQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadWidgetFormDto>> result = new ResultDataControl<List<ReadWidgetFormDto>>();
            try
            {

                IQueryable<WidgetTemplate> widgetQuery = this._applicationDbContext.WidgetTemplates
                    .Where(x => x.Id == request.WidgetTemplateId && x.WidgetId == request.WidgetId).AsNoTracking().AsQueryable();

                if (request.OnlineAndOffline)
                {
                    widgetQuery = widgetQuery
                        .Where(x => x.State == (int)StateEnum.Online || x.State == (int)StateEnum.Offline).AsQueryable();
                }
                else
                {
                    widgetQuery = widgetQuery
                        .Where(x => x.State == (int)request.State).AsQueryable();
                }


                ICollection<WidgetForm> widgetFormResult = await widgetQuery.AsNoTracking()
                    .Include(x => x.WidgetService)
                    .ThenInclude(x => x.WidgetForms)
                    .ThenInclude(x => x.WidgetForm_WidgetFormInputs)
                    .ThenInclude(x=>x.WidgetFormInput)
                    .Select(x=> x.WidgetService.WidgetForms)
                    .AsNoTracking().AsQueryable().FirstOrDefaultAsync();

                if (widgetFormResult==null || widgetFormResult.Count <= 0)
                {
                    result.SuccessSetData(new List<ReadWidgetFormDto>());
                }
                else
                {
                    result.SuccessSetData(this._mapper.Map<List<ReadWidgetFormDto>>(widgetFormResult));
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }


}
