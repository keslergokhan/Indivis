using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageApiController : BaseApiController
    {


        [HttpPost]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageInModel pageInModel)
        {
            return Ok(pageInModel);
        }

        [HttpGet]
        [Route("url-control")]
        public async Task<IActionResult> GetUrlControl([FromBody] GetUrlControlInModel inModel)
        {
            IResultControl model = new ResultControl();


            return Ok(model);
        }
    }
}
