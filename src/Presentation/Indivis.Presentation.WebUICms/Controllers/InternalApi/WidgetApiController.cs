using Indivis.Core.Application.Features.Systems.Commands.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WidgetApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("remove-widget")]
        [HttpPost]
        public async Task<IActionResult> RemoveWidget([FromBody]WidgetRemoveApiReqModel req)
        {
            IResultControl removeResult = await this._mediator.Send(new RemovePageWidgetSystemCommand() {
                PageWidgetId = req.PageWidgetId
            });

            return Ok(removeResult);
        }
    }
}
