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
    public class UpdatePageWidgetSettingOrderMinusCommand : IRequest<IResultControl>
    {
        public Guid PageWidgetSettingId { get; set; }
    }

    public class UpdatePageWidgetSettingOrderMinusCommandHandler : IRequestHandler<UpdatePageWidgetSettingOrderMinusCommand, IResultControl>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdatePageWidgetSettingOrderMinusCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResultControl> Handle(UpdatePageWidgetSettingOrderMinusCommand request, CancellationToken cancellationToken)
        {
            IResultControl model = new ResultControl();
            PageWidgetSetting setting = await this._applicationDbContext.PageWidgetSettings.SingleAsync(x => x.Id == request.PageWidgetSettingId);

            if (setting.Order >= 0)
            {
                setting.Order = setting.Order + 1;
            }

            int resutl = await this._applicationDbContext.SaveChangesAsync();

            if (resutl >= 0)
            {
                model.Success();
            }
            else
            {
                model.Fail();
            }

            return model;
        }
    }
}
