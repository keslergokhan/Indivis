using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Controllers.Controllers
{
    public class PageController : Controller
    {
        public async Task<IActionResult> PageContent()
        {
            
            return View("~/Areas/WebUI/Pages/PageContent.cshtml");
        }
    }
}
