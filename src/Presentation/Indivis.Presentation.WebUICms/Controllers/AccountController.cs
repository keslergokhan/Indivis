using Indivis.Core.Application.Interfaces.Services;
using Indivis.Presentation.WebUICms.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    /// <summary>
    /// Kullanıcı işlemleri
    /// 
    /// Giriş / Çıkış / Şifre Yenileme
    /// </summary>
    public class AccountController : BaseController
    {
        private ILogger<AccountController> _logger;
        private readonly IIdentityService _ıdentityService;

        public AccountController(ILogger<AccountController> logger, IIdentityService ıdentityService)
        {
            _logger = logger;
            _ıdentityService = ıdentityService;
        }

        public async Task<IActionResult> Login()
        {
            //await _ıdentityService.PasswordSignInAsync("gokhan@gmail.com","Gokhan.123");
            ViewBag.Title = "Indivis Giriş";
            return View();
        }

        public async Task<IActionResult> Giris()
        {
            await _ıdentityService.PasswordSignInAsync("gokhan@gmail.com","Gokhan.123");
            ViewBag.Title = "Indivis Giriş";
            return Ok();
        }


    }
}
