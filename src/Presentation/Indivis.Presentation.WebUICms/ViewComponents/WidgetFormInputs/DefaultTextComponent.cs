using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUICms.ViewComponents.WidgetFormInputs
{
    public class DefaultTextComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(ReadWidgetFormInputDto input)
        {
            return View("~/Views/ViewComponents/WidgetFormInputs/DefaultTextComponentView.cshtml",input);
        }
    }
}
