using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels;
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
        public async Task<IActionResult> GetForm(Guid widgetId,Guid widgetTemplateId)
        {
            WidgetFormApiGetFormResModel model = new WidgetFormApiGetFormResModel();

            IResultDataControl<List<ReadWidgetFormDto>> widgetFormResult = await this._mediator.Send(new GetAllWidgetFormAndWidgetFormInputQuery()
            {
                LanguageId = HttpContext.GetCurrentLanguageId(),
                State = Core.Application.Enums.Systems.StateEnum.Online,
                WidgetTemplateId = widgetTemplateId,
                WidgetId = widgetId,
            });

            if (!widgetFormResult.IsSuccess)
            {
                throw new ViewDataNotFoundException(nameof(List<ReadWidgetFormDto>));
            }

            model.WidgetForms = widgetFormResult.Data;

            return View("~/Views/WidgetForm/WidgetFormBodyView.cshtml",model);
        }
    }
}
