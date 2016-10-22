using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedditOverflow
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // This route allows us to get rid of the Index tag
            // so it behaves just like reddit
            routes.MapRoute(
                "Subreddit search",
                "Subreddit/{id}",
                new { controller = "Subreddit", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Subreddit", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
