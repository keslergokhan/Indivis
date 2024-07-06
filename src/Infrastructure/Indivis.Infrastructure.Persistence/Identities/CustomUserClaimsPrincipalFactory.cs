using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Identities
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CustomUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity claimsIdentity = await base.GenerateClaimsAsync(user);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName,user.Name + " " + user.Surname));
            return claimsIdentity;

        }
    }
}
