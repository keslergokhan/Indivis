﻿using Indivis.Core.Application.Dtos.AccountDtos.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
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
