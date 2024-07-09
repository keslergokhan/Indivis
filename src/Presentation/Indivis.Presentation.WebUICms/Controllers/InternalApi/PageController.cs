using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {


        [HttpGet]
        [Route("getpagecategories")]
        public async Task<IActionResult> GetPageCategories()
        {
            return Ok();
        }

    }
}
