using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUICms.ViewComponents.WidgetFormInputs
{
    public class DefaultTextAreaComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ReadWidgetFormInputDto input)
        {
            return View("~/Views/ViewComponents/WidgetFormInputs/DefaultTextAreaView.cshtml", input);
        }
    }
}
