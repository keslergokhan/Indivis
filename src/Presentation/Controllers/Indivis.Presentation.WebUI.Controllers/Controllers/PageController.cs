using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Controllers.Controllers
{
    public class PageController : Controller
    {
        private readonly ICurrentRequest currentRequest;
        private readonly IEntityFeatureContext _entityFeatureContext;
        private IMediator _mediator;

        public PageController(ICurrentRequest currentRequest, IMediator mediator, IEntityFeatureContext entityFeatureContext)
        {
            this.currentRequest = currentRequest;
            _mediator = mediator;
            _entityFeatureContext = entityFeatureContext;
        }

        public async Task<IActionResult> PageContent()
        {

            return View("~/Areas/WebUI/Pages/PageContent.cshtml", currentRequest);
        }
    }
}
