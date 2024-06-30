using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Interfaces.Services;
using Indivis.Infrastructure.Persistence.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Services
{
    [DependencyRegister(typeof(IIdentityService), DependencyTypes.Scopet)]
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task PasswordSignInAsync(string email,string password)
        {
            ApplicationUser user = await this._userManager.FindByEmailAsync(email);
            var ss = await this._signInManager.PasswordSignInAsync(user, password, false,false);
        }
       

    }
}
