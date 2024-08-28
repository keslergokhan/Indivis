using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Results;
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
    public class WidgetFormComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public WidgetFormComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            WidgetFormComponentOutModel model = new WidgetFormComponentOutModel();


            IResultDataControl<List<ReadWidgetFormDto>> result = await this._mediator.Send(new GetAllWidgetFormAndWidgetFormInputQuery()
            {
                State = Core.Application.Enums.Systems.StateEnum.Online
            });

            if (result.IsSuccess)
            {
                model.WidgetFormList = result.Data;
            }


            return View("~/Views/ViewComponents/WidgetFormComponentView.cshtml",model);
        }
    }
}
