using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace notes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new
                {
                    controller = "Home",
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "Create",
                url: "notepad/create",
                defaults: new
                {
                    controller = "Home",
                    action = "Create"
                }
            );

            routes.MapRoute(
                name: "Note",
                url: "notepad/{label}",
                defaults: new { controller = "Home", action = "Selected", label = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Img",
                url: "Home/Img/{txt}",
                defaults: new { controller = "Home", action = "Img", txt = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            
        }
    }
}
