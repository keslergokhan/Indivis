using Indivis.Core.Application.Features.Urls.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageApiController : BaseApiController
    {


        [HttpPost]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageInModel pageInModel)
        {
            return Ok(pageInModel);
        }

        [HttpPost]
        [Route("check-url-full-path")]
        public async Task<IActionResult> GetUrlControl([FromBody] GetUrlControlInModel inModel)
        {
            IResultControl model = new ResultControl();

            IResultDataControl<CheckUrlFullPathQueryResult> checkUrlResult = await base.Mediator.Send(new CheckUrlFullPathQuery
            {
                FullPath = inModel.FullPath
            });

            return Ok(checkUrlResult);
        }
    }
}
