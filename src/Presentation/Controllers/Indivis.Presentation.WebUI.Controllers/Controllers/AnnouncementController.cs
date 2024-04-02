using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Controllers.Controllers
{
	public class AnnouncementController : Controller
	{
		public async Task<IActionResult> List()
		{
			return View("~/Areas/WebUI/Announcements/AnnouncementList.cshtml");
		}

		public async Task<IActionResult> Detail()
		{
            return View("~/Areas/WebUI/Announcements/AnnouncementDetail.cshtml");
        }

	}
}
