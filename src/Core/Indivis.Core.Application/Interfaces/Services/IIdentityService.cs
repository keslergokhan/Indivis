using Indivis.Core.Application.Dtos.AccountDtos.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        public Task<IResultDataControl<ReadUsersDto>> PasswordSignInAsync(string email, string password);
    }
}
