using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using ThingsWeNeed.Data.Core;
using Microsoft.AspNet.Identity;
using ThingsWeNeed.Service.Identity;

[assembly: OwinStartup(typeof(ThingsWeNeed.Service.Owin.Startup))]

namespace ThingsWeNeed.Service.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(TwnContext.Create);
            app.CreatePerOwinContext<TwnUserManager>(TwnUserManager.Create);
            app.CreatePerOwinContext<TwnSignInManager>(TwnSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions { 
                Provider = new CookieAuthenticationProvider(),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromHours(6),
                LoginPath = new PathString("/Users/Login")
            });
        }
    }
}
