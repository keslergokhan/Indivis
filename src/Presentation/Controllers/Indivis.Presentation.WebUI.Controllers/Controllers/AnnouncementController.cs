using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUI.Controllers.Controllers
{
	public class AnnouncementController : Controller
	{
		public async Task<IActionResult> List()
		{
			return View("~/Areas/WebUI/Pages/Announcements/AnnouncementList.cshtml");
		}

		public async Task<IActionResult> Detail()
		{
            return View("~/Areas/WebUI/Pages/Announcements/AnnouncementDetail.cshtml");
        }

	}
}
