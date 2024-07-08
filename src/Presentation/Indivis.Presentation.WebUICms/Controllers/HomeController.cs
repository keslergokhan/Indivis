using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("HomeView");
        }
    }
}
