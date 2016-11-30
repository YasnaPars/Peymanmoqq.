using BLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class ContactController : AdminAuthorizeController
    {
        [ChildActionOnly]
        public virtual ActionResult Select()
        {
            return PartialView(Views._PartialCount, Contact.Count());
        }

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Contact.Inbox());
        }

        public virtual ActionResult Inbox()
        {
            ViewBag.Title = "صندوق دریافت";
            return View(Views.Index, new Tuple<List<Contact>, int>(Contact.Select("inbox"), Contact.Count("inbox")));
        }

        public virtual ActionResult Star()
        {
            ViewBag.Title = "برچسب خورده ها";
            return View(Views.Index, new Tuple<List<Contact>, int>(Contact.Select("star"), Contact.Count("star")));
        }

        public virtual ActionResult Trash()
        {
            ViewBag.Title = "حذف شده ها";
            return View(Views.Index, new Tuple<List<Contact>, int>(Contact.Select("trash"), Contact.Count("trash")));
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    Contact.UpdateStar(id.Value);
                    return Content("ok");
                }
                catch
                {
                }
            }

            return Content(string.Empty);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult MoveInbox(int[] list)
        {
            try
            {
                Contact.Update(list);
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
        public virtual ActionResult Delete(int[] list)
        {
            try
            {
                Contact.Delete(list);
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
        public virtual ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    Contact.Update(id.Value);
                }
                catch
                {
                }

                return PartialView(Views._PartialDetails, Contact.Select(id.Value));
            }
            else
            {
                return Content(string.Empty);
            }
        }
    }
}