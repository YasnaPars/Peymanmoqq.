using System.Web.Mvc;
using System.Web.Routing;

namespace PeymanMq
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*js}", new { js = @".*\.js(/.*)?" }); // فایل های css و js از سیستم مسیریابی MVC حذف می شوند
            routes.IgnoreRoute("{*css}", new { css = @".*\.css(/.*)?" });
            routes.MapMvcAttributeRoutes(); // برنامه تمام attribute route های روی اکشن های مختلف را جمع آوری و رجیستر می کند
            routes.LowercaseUrls = true; // پشتیبانی توکار از Lowercase Generated URLs

            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: MVC.XML.Sitemap(),
                namespaces: new[] { "PeymanMq.Controllers" }
            );

            routes.MapRoute(
                name: "RSS",
                url: "rss",
                defaults: MVC.XML.RSS(),
                namespaces: new[] { "PeymanMq.Controllers" }
            );

            routes.MapRoute(
                name: "DynamicPage",
                url: "Page/{*pageName}",
                defaults: MVC.DynamicPage.Index(null),
                namespaces: new[] { "PeymanMq.Controllers" }
            );

            routes.MapRoute(
                name: "DetailsPage",
                url: "{controller}/{action}/{id}/{text}",
                namespaces: new[] { "PeymanMq.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = MVC.Home.Name,
                    action = MVC.Home.ActionNames.Index,
                    id = UrlParameter.Optional
                },
                namespaces: new[] { "PeymanMq.Controllers" }
            );
        }
    }
}