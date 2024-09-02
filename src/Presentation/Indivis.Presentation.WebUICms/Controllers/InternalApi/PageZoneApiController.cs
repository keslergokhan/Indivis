using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Presentation.WebUI.Widgets.Extensions;
using Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using Indivis.Presentation.WebUI.Widgets.ViewComponents.Widgets;
using Indivis.Presentation.WebUI.Widgets.WidgetServices.TestWidget;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Encodings.Web;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "BaseAdmin")]
    public class PageZoneApiController : ControllerBase
    {
        private readonly ICurrentResponse _currentResponse;
        private readonly IViewComponentHelper _viewComponentHelper;
        private readonly IMediator _mediator;
        private readonly TestWidgetService _widget;

        public PageZoneApiController(IMediator mediator, IViewComponentHelper viewComponentHelper, ICurrentResponse currentResponse, TestWidgetService widget)
        {
            _mediator = mediator;
            _viewComponentHelper = viewComponentHelper;
            _currentResponse = currentResponse;
            _widget = widget;
        }

        [HttpGet]
        public async Task<IActionResult> GetWidgetTemplate()
        {
            using StringWriter writer = new StringWriter();
            var sss = this._currentResponse.CurrentPage.PageZones.FirstOrDefault(x => x.Key == "widget-about-top-widgets").PageWidgets.FirstOrDefault();
            var result = await this._viewComponentHelper.InvokeAsync(nameof(DefaultWidgetComponent), new DefaultViewComponentInModel
            {
                PageWidget = sss
            });


            result.WriteTo(writer, HtmlEncoder.Default);

            return Content(writer.ToString());
        }
    }
}
