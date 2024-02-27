using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Features.Systems.Queries.Urls;
using Indivis.Core.Application.Features.Urls.Queries;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Indivis.Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        private IEntityFeatureContext _entityFeatureContext;


        public HomeController(ILogger<HomeController> logger, IMediator mediator , IEntityFeatureContext entityFeatureContext,ICurrentRequest currentRequest)
        {
            _logger = logger;
            _mediator = mediator;
            _entityFeatureContext = entityFeatureContext;
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            IResultControl resultControl = new ResultControl();
            resultControl.Success();


            IResultDataControl<ErrorViewModel> result = new ResultDataControl<ErrorViewModel>();

            result.SuccessSetData(new ErrorViewModel() { RequestId = "sdfsdf" });

            var sss = result.Data;
            
            IResultDataControl<ErrorViewModel> result2 = new ResultDataControl<ErrorViewModel>();

            result2.Fail(new ExceptionResult("Hata","bu bir hatadýr",new ArgumentNullException("sdfsdfsd ")));

            if (result.IsSuccess)
            {

            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
