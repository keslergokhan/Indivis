using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [Route("get-all-page-zone-widgets/{pageZoneId:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAllPageZoneWidgets(Guid pageZoneId)
        {
            IResultDataControl<WidgetApiGetAllPageZoneWidgetsResModel> model = new ResultDataControl<WidgetApiGetAllPageZoneWidgetsResModel>();
            WidgetApiGetAllPageZoneWidgetsResModel data = new WidgetApiGetAllPageZoneWidgetsResModel();

            IResultDataControl<List<ReadPageWidgetDto>> pageWidgetList = await this._mediator.Send(new GeyByZoneIdAllPageWidgetSystemQuery()
            {
                PageZoneId = pageZoneId
            });

            if (!pageWidgetList.IsSuccess)
            {
                throw new Exception("Teknik bir problem yaşandı !");
            }

            data.PageWidget = pageWidgetList.Data;

            model.SetData(data);

            return Ok(model);
        }
    }
}
