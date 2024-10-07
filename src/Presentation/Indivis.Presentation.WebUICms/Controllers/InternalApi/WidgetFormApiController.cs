using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Systems.Commands.Widgets;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Authorize(Roles = "BaseAdmin")]
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
        [Route("update-widget")]
        public async Task<IActionResult> UpdateWidget([FromBody] WidgetFormApiUpdateWidgetReqModel req)
        {
            IResultDataControl<WidgetFormApiUpdateWidgetResModel> model = new ResultDataControl<WidgetFormApiUpdateWidgetResModel>();
            WidgetFormApiUpdateWidgetResModel data = new WidgetFormApiUpdateWidgetResModel();

            string jsonData = JsonSerializer.Serialize(req.WidgetData);


            UpdatePageWidgetSystemCommend addWidgetCommand = new UpdatePageWidgetSystemCommend()
            {
                PageWidget = new Core.Application.Dtos.CoreEntityDtos.Widgets.Writes.WritePageWidgetDto
                {
                    Id = req.WidgetSetting.PageWidgetId,
                    State = (int)StateEnum.Online,
                    WidgetId = req.WidgetSetting.WidgetId,
                    WidgetJsonData = JsonSerializer.Serialize(req.WidgetData),
                    LanguageId = HttpContext.GetCurrentLanguageId(),
                    PageZoneId = req.WidgetSetting.PageZoneId,
                    ModifiedDate = null,
                    CreateDate = DateTime.Now,
                    PageWidgetSetting = new Core.Application.Dtos.CoreEntityDtos.Widgets.Writes.WritePageWidgetSettingDto
                    {
                        Id = req.WidgetSetting.PageWidgetSettingId,
                        Name = req.WidgetSetting.Name,
                        Grid = req.WidgetSetting.Grid,
                        IsAsync = false,
                        Order = 1,
                        State = (int)StateEnum.Online,
                        IsShow = req.WidgetSetting.IsShow,
                        ClassCustom = "",
                        WidgetTemplateId = req.WidgetSetting.WidgetTemplateId,
                        CreateDate = DateTime.Now

                    }

                }
            };

            IResultDataControl<ReadPageWidgetDto> addPageWidgetResult = await this._mediator.Send(addWidgetCommand);

            if (!addPageWidgetResult.IsSuccess)
            {
                model.Fail(addPageWidgetResult.Error);
            }
            else
            {
                data.PageWidget = addPageWidgetResult.Data;
                model.SuccessSetData(data);
            }

            model.SetData(data);
            return Ok(model);


        }

        [Route("remove-widget")]
        [HttpPost]
        public async Task<IActionResult> RemoveWidget([FromBody] WidgetRemoveApiReqModel req)
        {
            IResultControl removeResult = await this._mediator.Send(new RemovePageWidgetSystemCommand()
            {
                PageWidgetId = req.PageWidgetId
            });

            return Ok(removeResult);
        }


        [HttpPost]
        [Route("add-widget")]
        public async Task<IActionResult> AddWidget([FromBody] WidgetFormApiAddWidgetReqModel req)
        {
            IResultDataControl<WidgetFormApiAddWidgetResModel> model = new ResultDataControl<WidgetFormApiAddWidgetResModel>();
            WidgetFormApiAddWidgetResModel data = new WidgetFormApiAddWidgetResModel();
            

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

            if (!addPageWidgetResult.IsSuccess)
            {
                model.Fail(addPageWidgetResult.Error);
            }
            else
            {
                data.PageWidget = addPageWidgetResult.Data;
                model.SuccessSetData(data);
            }
            
            model.SetData(data);
            return Ok(model);
        }


        [HttpPost]
        [Route("up-widget")]
        public async Task<IActionResult> UpWidget([FromBody] WidgetFormApiUpAndDownReqModel req)
        {

            IResultControl plusControl = await this._mediator.Send(new UpdatePageWidgetSettingOrderPlusCommand()
            {
                PageWidgetSettingId = req.PageWidgetSettingId,
                PageZoneId = req.PageZoneId,
            });

            return Ok(plusControl);
        }


        [HttpPost]
        [Route("down-widget")]
        public async Task<IActionResult> DownWidget([FromBody] WidgetFormApiUpAndDownReqModel req)
        {
            IResultControl plusControl = await this._mediator.Send(new UpdatePageWidgetSettingOrderMinusCommand()
            {
                PageWidgetSettingId = req.PageWidgetSettingId,
                PageZoneId = req.PageZoneId,
            });

            return Ok(plusControl);
        }

        #region IFrameForm
        [HttpGet]
        [Route("getUpdateform/{pageWidgetId:guid}")]
        public async Task<IActionResult> GetUpdateFrom(Guid pageWidgetId)
        {
            WidgetFormApiGetDynamicUpdateFormResModel model = new WidgetFormApiGetDynamicUpdateFormResModel();

            
            IResultDataControl<ReadPageWidgetDto> resultPageWidget = await this._mediator.Send(new GetByIdPageWidgetSystemQuery()
            {
                Id = pageWidgetId
            });

            if (!resultPageWidget.IsSuccess)
            {
                throw new ArgumentNullException($"{nameof(GetByIdPageWidgetSystemQuery)} result not null !");
            }

            model.PageWidget = resultPageWidget.Data;
            
            IResultDataControl<List<ReadWidgetFormDto>> widgetFormResult = await this._mediator.Send(new GetAllWidgetFormAndWidgetFormInputQuery()
            {
                LanguageId = HttpContext.GetCurrentLanguageId(),
                State = Core.Application.Enums.Systems.StateEnum.Online,
                WidgetTemplateId = model.PageWidget.PageWidgetSetting.WidgetTemplateId,
                WidgetId = model.PageWidget.WidgetId,
            });

            model.WidgetForms = widgetFormResult.Data;



            return View("~/Views/WidgetForm/UpdateWidgetFormBodyView.cshtml",model);
        }

        [HttpGet]
        [Route("getform/{widgetId:guid}/{widgetTemplateId:guid}")]
        public async Task<IActionResult> GetForm(Guid widgetId,Guid widgetTemplateId)
        {
            WidgetFormApiGetDynamicFormResModel model = new WidgetFormApiGetDynamicFormResModel();

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

        #endregion IFrameForm End
    }
}
