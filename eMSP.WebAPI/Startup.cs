using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Web.Http;
using AngularJSAuthentication.API;

[assembly: OwinStartup(typeof(eMSP.WebAPI.Startup))]

namespace eMSP.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureAuth(app);


            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, AngularJSAuthentication.API.Migrations.Configuration>());
        }
    }
}
