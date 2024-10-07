﻿using Indivis.Core.Application.Interfaces.Data;
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
        public Guid PageZoneId { get; set; }
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

            List<PageWidgetSetting> pageWidgetSettings = await this._applicationDbContext.PageWidgets
                .Where(x => x.PageZoneId == request.PageZoneId)
                .Select(x => x.PageWidgetSetting).OrderBy(x => x.Order).ToListAsync();

            PageWidgetSetting setting = await this._applicationDbContext.PageWidgetSettings.SingleAsync(x => x.Id == request.PageWidgetSettingId);


            int index = pageWidgetSettings.IndexOf(setting);


            if (pageWidgetSettings.Count == setting.Order)
            {
                model.Success();
                return model;
            }
            else
            {
                int newIndex = (index + 1);
                if (pageWidgetSettings.Count >= newIndex)
                {
                    int order = setting.Order;
                    PageWidgetSetting updateSetting = pageWidgetSettings[newIndex];
                    setting.Order = updateSetting.Order;
                    updateSetting.Order = order;
                }

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
