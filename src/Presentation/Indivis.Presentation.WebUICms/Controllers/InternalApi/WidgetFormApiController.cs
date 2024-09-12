using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetFormApiController : Controller
    {
        [HttpGet]
        [Route("getform/{widgetId:guid}/{widgetTemplateId:guid}")]
        public IActionResult GetForm()
        {
            return View("~/Views/WidgetForm/WidgetFormBodyView.cshtml");
        }
    }
}
