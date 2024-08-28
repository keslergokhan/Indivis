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
        IOnlineAndOfflineQuery,
        IStateQuery
    {
        public bool OnlineAndOffline { get; set; }
        public StateEnum State { get; set; }
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
                IQueryable<WidgetForm> widgetFormQuery = this._applicationDbContext.WidgetForms.AsNoTracking().AsQueryable();

                if (request.OnlineAndOffline)
                {
                    widgetFormQuery = widgetFormQuery
                        .Where(x => x.State == (int)StateEnum.Online || x.State == (int)StateEnum.Offline).AsQueryable();
                }
                else
                {
                    widgetFormQuery = widgetFormQuery
                        .Where(x => x.State == (int)request.State).AsQueryable();
                }


                List<WidgetForm> resultWidgetForm = widgetFormQuery
                    .Include(x => x.WidgetForm_WidgetFormInputs).ThenInclude(x=>x.WidgetFormInput).AsNoTrackingWithIdentityResolution().ToList();
                result.SuccessSetData(this._mapper.Map<List<ReadWidgetFormDto>>(resultWidgetForm));
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }


}
