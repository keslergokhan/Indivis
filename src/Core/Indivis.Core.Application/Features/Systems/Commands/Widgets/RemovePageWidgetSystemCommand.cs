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

namespace Indivis.Core.Application.Features.Systems.Commands.Widgets
{
    public class RemovePageWidgetSystemCommand : IRequest<IResultControl>
    {
        public Guid PageWidgetId { get; set; }
    }

    public class RemovePageWidgetSystemCommandHander : IRequestHandler<RemovePageWidgetSystemCommand, IResultControl>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public RemovePageWidgetSystemCommandHander(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResultControl> Handle(RemovePageWidgetSystemCommand request, CancellationToken cancellationToken)
        {
            IResultControl model = new ResultControl();

            try
            {
                PageWidget pageWidget = await this._applicationDbContext.PageWidgets.Include(x => x.PageWidgetSetting).Where(x => x.Id == request.PageWidgetId).SingleAsync();

                pageWidget.State = (int)StateEnum.Offline;
                pageWidget.PageWidgetSetting.State = (int)StateEnum.Offline;

                int result = await this._applicationDbContext.SaveChangesAsync();

                if (result > 0)
                {
                    model.Success();
                }
                else
                {
                    model.Fail();
                }
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
