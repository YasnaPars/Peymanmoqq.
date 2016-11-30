using BLL;
using Ionic.Zip;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class OrderController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Select(int pageIndex, int pageSize)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Order.Select(pageIndex, pageSize, out total),
                TotalRows = total
            };

            return result;
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Delete(int? id, string url)
        {
            try
            {
                if (id.HasValue)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Data/DenyUsers"), url)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Data/DenyUsers/" + url));
                    }

                    Order.Delete(id.Value);
                    return Json(true);
                }
            }
            catch
            {
            }

            return Json(false);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult DeleteAll(int[] list, string[] urlList)
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                for (int i = 0; i < list.Length; i++)
                {
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Data/DenyUsers"), urlList[i])))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Data/DenyUsers/" + urlList[i]));
                    }

                    Order.Delete(list[i]);
                }

                return Content("ok");
            }
            catch
            {
                return Content(string.Empty);
            }
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult UpdateRank(int id, string type)
        {
            try
            {
                Order.Update(id, type);
                return Json(true);
            }
            catch
            {
            }

            return Json(false);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult UpdateStar(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    Order.Update(id.Value);
                    return Content("ok");
                }
                catch
                {
                }
            }

            return Content(string.Empty);
        }

        public virtual ActionResult Details(int id)
        {
            return View(Order.Select(id));
        }

        public virtual ActionResult Download(string fileName)
        {
            var ms = new MemoryStream();

            using (var zip = new ZipFile())
            {
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    zip.AddFile(Path.Combine(Server.MapPath("~/Data/DenyUsers"), fileName), "File");
                }

                zip.Save(ms);
            }

            ms.Position = 0;
            return File(ms, "application/zip", "order.zip");
        }
    }
}