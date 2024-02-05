using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Indivis.Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            IResultControl resultControl = new ResultControl();
            resultControl.Success();


            IDataResultControl<ErrorViewModel> result = new DataResultControl<ErrorViewModel>();

            result.SuccessSetData(new ErrorViewModel() { RequestId = "sdfsdf" });

            var sss = result.Data;

            IDataResultControl<ErrorViewModel> result2 = new DataResultControl<ErrorViewModel>();

            result2.Fail(new ExceptionResult("Hata","bu bir hatadýr",new ArgumentNullException("sdfsdfsd ")));

            if (result.IsSuccess)
            {

            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
