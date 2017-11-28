using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using CarsWithIdentity.Models;
using System;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Owin;
using Microsoft.Owin.Security.Cookies;

namespace CarsWithIdentity.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ApplicationDbContext());

            app.CreatePerOwinContext<UserManager<ApplicationUser>>((options, context) =>
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>())));

            app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
                new RoleManager<ApplicationRole>(
                    new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }

}
