using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
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
        public async Task<IActionResult> GetWidgetTemplate([FromQuery]Guid pageWidgetId)
        {
            IResultDataControl<ReadPageWidgetDto> pageWidgetResult = await this._mediator.Send(new GetByIdPageWidgetSystemQuery()
            {
                Id = pageWidgetId
            });

            if (!pageWidgetResult.IsSuccess)
            {
                throw new PageWidgetNotFaundException();
            }


            return View("~/Areas/Widgets/WidgetTemplateApiResult.cshtml",pageWidgetResult);
        }
    }
}
