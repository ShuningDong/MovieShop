using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ASP.NET MVC Routing
            // 2 kinds of routing
            // 1. Convention based Routing
            // 2. Attribute based Routing - introduced in MVC 5 -- preferred
            // Routing in MVC is pattern matching technique
            // {}  braces are place holder, they will be used for incoming URL 
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
