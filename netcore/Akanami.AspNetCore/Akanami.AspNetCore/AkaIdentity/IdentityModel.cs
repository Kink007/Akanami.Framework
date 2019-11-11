using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akanami.AspNetCore.AkaIdentity
{
    public class ApplicationUser : IdentityUser<int>
    {

    }

    public class ApplicationRole : IdentityRole<int>
    {
        
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
        
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
        
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int> 
    {

    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                                                          ApplicationRole,
                                                          int,
                                                          ApplicationUserClaim,
                                                          ApplicationUserRole,
                                                          ApplicationUserLogin,
                                                          ApplicationRoleClaim,
                                                          ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser,
                                                  ApplicationRole,
                                                  ApplicationDbContext,
                                                  int,
                                                  ApplicationUserClaim,
                                                  ApplicationUserRole,
                                                  ApplicationUserLogin,
                                                  ApplicationUserToken,
                                                  ApplicationRoleClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
            
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole,
                                                  ApplicationDbContext,
                                                  int,
                                                  ApplicationUserRole,
                                                  ApplicationRoleClaim>
    {
        public ApplicationRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
            
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, 
                                      IOptions<IdentityOptions> optionsAccessor, 
                                      IPasswordHasher<ApplicationUser> passwordHasher, 
                                      IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
                                      IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
                                      ILookupNormalizer keyNormalizer, 
                                      IdentityErrorDescriber errors, 
                                      IServiceProvider services, 
                                      ILogger<ApplicationUserManager> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            
        }
    }

    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store, 
                                      IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, 
                                      ILookupNormalizer keyNormalizer, 
                                      IdentityErrorDescriber errors, 
                                      ILogger<ApplicationRoleManager> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, 
                                        IHttpContextAccessor contextAccessor, 
                                        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, 
                                        IOptions<IdentityOptions> optionsAccessor, 
                                        ILogger<ApplicationSignInManager> logger, 
                                        IAuthenticationSchemeProvider schemes, 
                                        IUserConfirmation<ApplicationUser> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            
        }
    }
}
