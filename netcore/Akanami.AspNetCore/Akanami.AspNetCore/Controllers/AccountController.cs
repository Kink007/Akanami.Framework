using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akanami.AspNetCore.AkaIdentity;
using Akanami.AspNetCore.Dtos.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Akanami.AspNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationUserManager userManager;

        public AccountController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        
        public async Task<IdentityResult> Register([FromBody]RegisterDtos registerDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDto.Name,
                Email = registerDto.Name
            };

            var result = await this.userManager.CreateAsync(user, registerDto.Password);

            return result;
        }

    }
}