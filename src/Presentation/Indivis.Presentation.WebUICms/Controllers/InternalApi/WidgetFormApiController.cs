using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Systems.Commands.Widgets;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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


        [HttpPost]
        [Route("add-widget")]
        public async Task<IActionResult> AddWidget([FromBody] WidgetFormApiAddWidgetReqModel req)
        {
            string jsonData = JsonSerializer.Serialize(req.WidgetData);


            AddPageWidgetSystemCommend addWidgetCommand = new AddPageWidgetSystemCommend()
            {
                PageWidget = new Core.Application.Dtos.CoreEntityDtos.Widgets.Writes.WritePageWidgetDto
                {
                    State = (int)StateEnum.Online,
                    WidgetId = req.WidgetSetting.WidgetId,
                    WidgetJsonData = JsonSerializer.Serialize(req.WidgetData),
                    LanguageId = HttpContext.GetCurrentLanguageId(),
                    PageZoneId = req.WidgetSetting.PageZoneId,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now,
                    PageWidgetSetting = new Core.Application.Dtos.CoreEntityDtos.Widgets.Writes.WritePageWidgetSettingDto
                    {
                        Name = req.WidgetSetting.Name,
                        Grid = req.WidgetSetting.Grid,
                        IsAsync = false,
                        Order = 1,
                        State = (int)StateEnum.Online,
                        IsShow = false,
                        ClassCustom = "",
                        WidgetTemplateId = req.WidgetSetting.WidgetTemplateId,
                        CreateDate = DateTime.Now
                        
                    }

                }
            };

            IResultDataControl<ReadPageWidgetDto> addPageWidgetResult = await this._mediator.Send(addWidgetCommand);

            return Ok("{}");
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
