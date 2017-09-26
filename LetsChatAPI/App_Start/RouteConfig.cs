using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace LetsChatAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Default", "{controller}/{action}/{id}",
            //    new { controller = "ChatWindow", action = "Chat", id = UrlParameter.Optional }); 
            // Route for Client

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            // Route for Admin

            routes.MapHttpRoute("API Default", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );


        }
    }
}
