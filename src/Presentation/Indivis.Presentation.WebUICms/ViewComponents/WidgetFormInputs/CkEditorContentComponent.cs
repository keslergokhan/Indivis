using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.ViewComponents.WidgetFormInputs;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.ViewComponents.WidgetFormInputs
{

    public class CkEditorContentComponent : BaseWidgetInputComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(WidgetInputComponentReqModel req)
        {
            WidgetTextInputComponentResModel res = new WidgetTextInputComponentResModel();
            res.Input = req.Input;
            if (req.PageWidget != null)
            {
                res.Value = base.JsonParseToValue<string>(req.Input, req.PageWidget);
            }

            return View("~/Views/ViewComponents/WidgetFormInputs/CkEditorContentComponentView.cshtml", res);
        }
    }
}
