using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.Controllers.Common;
using Indivis.Presentation.WebUI.Widgets.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Controllers.Controllers.InternalApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "BaseAdmin")]
    public class PageZoneApiController : BaseController
    {
        private readonly IMediator _mediator;

        public PageZoneApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWidgetTemplate()
        {

            return View("~/Areas/Widgets/WidgetTemplateApiResult.cshtml");
        }
    }
}
