using AutoMapper;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace Indivis.Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, IMediator mediator = null)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var sss = await this._mediator.Send(new GetByIdPageQuery() { Id = Guid.Parse("A2098C4A-F18B-4E41-AC31-BE8BA9D0342A") });
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
