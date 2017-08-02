using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleMvcContacts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetAllPeople", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AddPerson",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "AddPerson", id = UrlParameter.Optional }
           );
        }
    }
}
