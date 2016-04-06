using System.Web.Mvc;
using System.Web.Routing;

namespace Store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );
            /*
            routes.MapRoute(
                name: "Custom",
                url: "Custom/CustomAction/{id}",
                defaults: new { controller = "Custom", action = "CustomAction", id = UrlParameter.Optional }
            );*/

            /*
            routes.Add(new Route
    ("Custom/CustomAction", new MvcRouteHandler())
    {
        Defaults = new RouteValueDictionary(new 
		{ controller = "Custom", action = "CustomAction” }),
    }
    );*/
        }
    }
}