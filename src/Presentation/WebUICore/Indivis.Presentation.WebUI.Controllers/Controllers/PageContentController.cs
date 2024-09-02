using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUI.Controllers.Controllers
{
    public class PageContentController : Controller
    {
        private readonly ICurrentRequest currentRequest;
        private readonly IEntityFeatureContext _entityFeatureContext;
        private IMediator _mediator;

        public PageContentController(ICurrentRequest currentRequest, IMediator mediator, IEntityFeatureContext entityFeatureContext)
        {
            this.currentRequest = currentRequest;
            _mediator = mediator;
            _entityFeatureContext = entityFeatureContext;
        }

        public async Task<IActionResult> PageContent()
        {
            return View("~/Areas/WebUI/Pages/PageContent/PageContent.cshtml", currentRequest);
        }
    }
}
