using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyFirstMVCApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //sets up attribute routing, a much better way to do custom routes, defined in the controller in the attribute
            routes.MapMvcAttributeRoutes();
            
            
            //shitty/fragile way to do custom routes
            //custom routes must be defined before the default route
            //{ } means its a passed in parameter, otherwise its hard coded 
            //routes.MapRoute(
            //    "LandscapeCompletionDate",
            //    "landscapes/completed/{year}/{month}",
            //    new { controller = "Landscapes", action = "ByCompletionDate" },//);
            //
            //    //set constraints on the accepted input characters -> 4 digits for year and 2 digits for month
            //    new { year = @"\d{4}", month = @"\d{2}" });
            //    //new { year = @"2015|2016" });
                
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
