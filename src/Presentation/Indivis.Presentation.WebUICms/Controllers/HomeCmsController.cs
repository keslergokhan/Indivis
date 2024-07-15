using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    public class HomeCmsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/HomeView.cshtml");
        }
    }
}
