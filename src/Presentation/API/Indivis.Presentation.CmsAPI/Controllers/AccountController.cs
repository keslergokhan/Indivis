using Indivis.Core.Application.Dtos.AccountDtos.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Interfaces.Services;
using Indivis.Presentation.CmsAPI.Models.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Indivis.Presentation.CmsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            IResultDataControl<ReadUsersDto> result = await _identityService.PasswordSignInAsync(loginRequest.Email, loginRequest.Password);
            return Ok(result);
        }

    }
}
