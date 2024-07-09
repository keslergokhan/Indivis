using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.CmsAPI.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
         
    }
}
