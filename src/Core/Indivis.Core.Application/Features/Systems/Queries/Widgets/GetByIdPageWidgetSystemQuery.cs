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
    public class GetByIdPageWidgetSystemQuery
        :IRequest<IResultDataControl<ReadPageWidgetDto>>
    {
        public Guid Id { get; set; }    
    }

    public class GetByIdPageWidgetSystemQueryHandler
        : IRequestHandler<GetByIdPageWidgetSystemQuery, IResultDataControl<ReadPageWidgetDto>>
    {

        private readonly IApplicationDbContext _applicaitonDbContext;
        private readonly IMapper _mapper;

        public GetByIdPageWidgetSystemQueryHandler(IApplicationDbContext applicaitonDbContext, IMapper mapper)
        {
            _applicaitonDbContext = applicaitonDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadPageWidgetDto>> Handle(GetByIdPageWidgetSystemQuery request, CancellationToken cancellationToken)
        {

            IResultDataControl<ReadPageWidgetDto> result = new ResultDataControl<ReadPageWidgetDto>();
            try
            {
                PageWidget pageWidget = await this._applicaitonDbContext.PageWidgets
                    .Where(x => x.Id == request.Id)
                    .Include(x=>x.Widget)
                    .Include(x => x.PageWidgetSetting).ThenInclude(x => x.WidgetTemplate).ThenInclude(x => x.WidgetService)
                    .AsNoTracking().FirstOrDefaultAsync();

                if (pageWidget!=null)
                {
                    result.SuccessSetData(this._mapper.Map<ReadPageWidgetDto>(pageWidget));
                }
                else
                {
                    result.Fail();
                }

            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
        
            return result;
        }
    }
}
