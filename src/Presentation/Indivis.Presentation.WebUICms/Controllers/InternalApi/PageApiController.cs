using Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageApiController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageInModel pageInModel)
        {
            return Ok(pageInModel);
        }
    }
}
