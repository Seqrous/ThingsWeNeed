using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Service.Identity
{
    public class TwnSignInManager : SignInManager<UserEntity, string>
    {
        public TwnSignInManager(TwnUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserEntity user)
        {
            return UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static TwnSignInManager Create(IdentityFactoryOptions<TwnSignInManager> options, IOwinContext context)
        {
            return new TwnSignInManager(context.GetUserManager<TwnUserManager>(), context.Authentication);
        }
    }
}