using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlowOut
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "{controller}/{action}/{name}/{email}",
                defaults: new { controller = "Contact", action = "Email", name = UrlParameter.Optional, email = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Rental",
                url: "{controller}/{action}/{name}/{price}",
                defaults: new { controller = "Rental", action = "Instrument", name = UrlParameter.Optional, price = UrlParameter.Optional }
            );
        }
    }
}
