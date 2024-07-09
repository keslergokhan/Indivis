using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.CmsAPI.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {

    }
}
