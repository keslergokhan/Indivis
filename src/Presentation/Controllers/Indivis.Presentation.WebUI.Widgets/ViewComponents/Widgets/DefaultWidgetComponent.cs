using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.Widgets.Common.ViewComponents;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.ViewComponents.Widgets
{
    public class DefaultWidgetComponent : BaseViewComponent
    {
        public DefaultWidgetComponent(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(DefaultViewComponentInModel inModel)
        {
            try
            {
				object serviceResult = await base.GetWidgetServiceExecuteAsync(inModel.PageWidget);
				string template = inModel.PageWidget.PageWidgetSetting.WidgetTemplate.Template;
				return View($"~/Areas/Widgets{template}", serviceResult);
			}
            catch
            {
                return View($"~/Areas/Widgets/ErrorWidget/ErrorWidget.cshtml", inModel);
            }
            
        }
    }
}
