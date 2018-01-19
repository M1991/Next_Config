using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NextFlex_Configurator.App_Start;
using NextFlex_Configurator.Models;
using NextFlex_Configurator.Services;
using Owin;
using System.Web.Mvc;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(NextFlex_Configurator.Startup))]
namespace NextFlex_Configurator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //   var services = new ServiceCollection();
            //   ConfigureAuth(app);

            // ConfigureServices(services);
            //   var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            //  DependencyResolver.SetResolver(resolver);

                app.CreatePerOwinContext(() => new DbContextEntities());
            //   Change in CustomIdentityModel if cahnged this (nameConflicts)  app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
              //  app.AddIdentity
                app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
                app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
                app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            /*  app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                  new RoleManager<AppRole>(
                      new RoleStore<AppRole>(context.<DbContextEntities>()))); */
            // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DbContextEntities));
            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Home/Index"),
                });

            }
    }
}
