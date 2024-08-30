using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    public class WidgetFormCmsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View("~/Views/WidgetForm/WidgetFormView.cshtml");
        }
    }
}
