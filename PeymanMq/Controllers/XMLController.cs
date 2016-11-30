using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PeymanMq.Controllers
{
    public partial class XMLController : BaseController
    {
        [OutputCache(Duration = 1200, VaryByParam = "none")]
        public virtual ContentResult RSS()
        {
            IEnumerable<PostToXML> items = SelectRssFeed();
            XDocument rss = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
              new XElement("rss",
                new XAttribute("version", "2.0"),
                  new XElement("channel",
                    new XElement("title", "آخرین مطالب سایت"),
                    new XElement("link", "http://" + Request.Url.Host + "/rss"),
                    new XElement("description", "آخرین مطالب سایت " + ClsMain.SiteTitle),
                    new XElement("copyright", "(c)" + DateTime.Now.Year + ", تمام حقوق این وب سایت برای " + ClsMain.SiteTitle + " محفوظ می باشد"),
                  from item in items
                  select new XElement("item",
                    new XElement("title", item.Title),
                    new XElement("description", item.Description),
                    new XElement("link", item.Link),
                    new XElement("pubDate", item.PublishDate)
                  )
                )
              )
            );

            return Content(rss.ToString(), "text/xml");
        }

        [OutputCache(Duration = 7200, VaryByParam = "none")]
        public virtual ContentResult Sitemap()
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            IEnumerable<PostToXML> items = SelectLinks();
            XDocument sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "urlset",
                    from item in items
                    select new XElement("url",
                      new XElement("loc", item.Link),
                      new XElement("changefreq", "monthly"),
                      new XElement("priority", "0.5")
                    )
                )
            );

            return Content(sitemap.ToString(), "text/xml");
        }

        public IEnumerable<PostToXML> SelectRssFeed()
        {
            // ترکیب چند جدول
            //List<PostToXML> list1 = Blog.SelectRSS();
            //List<PostToXML> list2 = Blog.SelectRSS();
            //IEnumerable<PostToXML> total = list1.Concat(list2); // list1.Union(list2);
            //return total;
            return Blog.SelectRSS();
        }

        public IEnumerable<PostToXML> SelectLinks()
        {
            return Blog.SelectSiteMap()
                   .Union(BlogCategory.SelectSiteMap())
                   .Union(Product.SelectSiteMap())
                   .Union(ProductCategory.SelectSiteMap())
                   .Union(DynamicMenu.SelectSiteMap());
        }
    }
}