using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eMSP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "eMSPAppAccounts",
               url: "Account",
               defaults: new { controller = "Home", action = "Login" }
           );
            routes.MapRoute(
                name: "eMSPAppDefault",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );

           
        }
    }
}
