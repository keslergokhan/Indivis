using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetFormApiController : Controller
    {
        private readonly IMediator _mediator;

        public WidgetFormApiController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        [Route("getform/{widgetId:guid}/{widgetTemplateId:guid}")]
        public IActionResult GetForm()
        {
            return View("~/Views/WidgetForm/WidgetFormBodyView.cshtml");
        }
    }
}
