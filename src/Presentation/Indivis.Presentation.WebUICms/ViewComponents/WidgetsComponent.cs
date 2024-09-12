using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.ViewComponents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUICms.ViewComponents
{
    public class WidgetsComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public WidgetsComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            WidgetComponentOutModel model = new WidgetComponentOutModel();

            IResultDataControl<List<ReadWidgetDto>> resultWidgets = await this._mediator.Send(new GetAllWidgetsSystemQuery()
            {
                State = Core.Application.Enums.Systems.StateEnum.Online,
                LanguageId = HttpContext.GetCurrentLanguageId()
            });


            if (!resultWidgets.IsSuccess)
            {
                throw new Exception("Widget listesine ulaşılamdı !");
            }

            model.Widgets = resultWidgets.Data;

            return View("~/Views/ViewComponents/WidgetComponent.cshtml", model);
        }
    }
}
