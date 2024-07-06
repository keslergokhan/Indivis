using AutoMapper;
using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.AccountDtos.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Interfaces.Services;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities;
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
        private readonly IMapper _mapper;

        public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadUsersDto>> PasswordSignInAsync(string email, string password)
        {
            IResultDataControl<ReadUsersDto> result = new ResultDataControl<ReadUsersDto>();

            try
            {
                SignInResult signResult = await this._signInManager.PasswordSignInAsync(email, password, false, false);

                if (signResult.Succeeded)
                {
                    ApplicationUser findUserResult = await _userManager.FindByEmailAsync(email);
                    result.SetData(this._mapper.Map<ReadUsersDto>(findUserResult));
                    return result;
                }
                else
                {
                    result.Fail();
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }


    }
}
