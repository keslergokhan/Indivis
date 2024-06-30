using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        public Task PasswordSignInAsync(string email, string password);
    }
}
