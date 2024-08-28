using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.ViewComponents.Widgets.WidgetFormInputs
{
    public class DefaultTextAreaComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ReadWidgetFormInputDto input)
        {
            return View("~/Areas/Widgets/ViewComponents/WidgetFormInputs/DefaultTextAreaView.cshtml", input);
        }
    }
}
