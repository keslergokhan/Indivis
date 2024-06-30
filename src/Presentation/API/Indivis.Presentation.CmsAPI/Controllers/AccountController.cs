using Indivis.Core.Application.Interfaces.Services;
using Indivis.Presentation.CmsAPI.Models.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.CmsAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _ıdentityService;

        public AccountController(IIdentityService ıdentityService)
        {
            _ıdentityService = ıdentityService;
        }

        [Authorize(Roles = "BaseAdmin")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok("{}");
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await _ıdentityService.PasswordSignInAsync("gokhan@gmail.com", "Gokhan.123");
            return Ok("");
        }
    }
}
