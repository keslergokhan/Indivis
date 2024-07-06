using Indivis.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Identities
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
