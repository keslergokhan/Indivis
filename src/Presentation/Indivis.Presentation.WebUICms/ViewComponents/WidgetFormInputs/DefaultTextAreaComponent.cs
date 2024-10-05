using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.ViewComponents;
using Indivis.Presentation.WebUICms.Models.ViewComponents.WidgetFormInputs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUICms.ViewComponents.WidgetFormInputs
{
    public class DefaultTextAreaComponent : BaseWidgetInputComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(WidgetInputComponentReqModel req)
        {
            WidgetTextInputComponentResModel res = new WidgetTextInputComponentResModel();
            res.Input = req.Input;
            if (req.PageWidget != null)
            {
                res.Value = base.JsonParseToValue<string>(req.Input, req.PageWidget);
            }

            return View("~/Views/ViewComponents/WidgetFormInputs/DefaultTextAreaView.cshtml", res);
        }
    }
}
