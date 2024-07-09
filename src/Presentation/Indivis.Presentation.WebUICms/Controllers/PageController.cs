using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    public class PageController : Controller
    {
        public async Task<IActionResult> CreatePage()
        {
            ViewBag.Title = "Yeni bir sayfa oluştur";
            return View("~/Views/Page/CreatePageView.cshtml");
        }

        public async Task<IActionResult> PageCategory()
        {
            ViewBag.Title = "Sayfa Kategorileri";
            return View("~/Views/Page/PageCategoryView.cshtml");
        }
    }
}
