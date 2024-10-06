using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes;
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
    public class UpdatePageWidgetSystemCommend : IRequest<IResultDataControl<ReadPageWidgetDto>>
    {
        public WritePageWidgetDto PageWidget { get; set; }
    }


    public class UpdatePageWidgetSystemCommendHandler : IRequestHandler<UpdatePageWidgetSystemCommend, IResultDataControl<ReadPageWidgetDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UpdatePageWidgetSystemCommendHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadPageWidgetDto>> Handle(UpdatePageWidgetSystemCommend request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadPageWidgetDto> model = new ResultDataControl<ReadPageWidgetDto>();
            try
            {
                PageWidget pageWidget = this._mapper.Map<PageWidget>(request.PageWidget);

                EntityEntry<PageWidget> entityEntry = this._applicationDbContext.PageWidgets.Update(pageWidget);

                int saveChanges = await this._applicationDbContext.SaveChangesAsync();

                if (saveChanges <= 0)
                {
                    throw new Exception($"PageWidget kayıt edilemedi ! {request.PageWidget.PageWidgetSetting.Name}  {request.PageWidget.PageZoneId}");
                }

                model.SuccessSetData(this._mapper.Map<ReadPageWidgetDto>(entityEntry.Entity));
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
