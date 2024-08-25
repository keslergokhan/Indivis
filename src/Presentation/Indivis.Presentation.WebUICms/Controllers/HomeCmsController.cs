using Indivis.Presentation.WebUICms.Attributes;
using Indivis.Presentation.WebUICms.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
	[CmsAddBreadcrumbAttributes(nameof(HomeCmsController), "Anasayfa", "/homecms/index",null)]
	public class HomeCmsController : BaseCmsController
    {
        public HomeCmsController()
        {
		}

        public IActionResult Index()
        {
            return View("~/Views/Home/HomeView.cshtml");
        }
    }
}
