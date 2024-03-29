﻿using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class CommentController : AdminAuthorizeController
    {
        public virtual ActionResult Index(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Select(int pageIndex, int pageSize, Status status, int? id)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Comment.Select(pageIndex, pageSize, status, out total, id),
                TotalRows = total
            };

            return result;
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Comment.Delete(id.Value);
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
        public virtual ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                return PartialView(Views._PartialUpdate, Comment.Select(id.Value));
            }
            else
            {
                return Content(string.Empty);
            }
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult UpdateStatus(int id, Status type)
        {
            try
            {
                Comment.Update(id, type);
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
        public virtual JsonResult Update(Comment obj)
        {
            JsonResult result = new JsonResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Comment.Update(obj);
                    result.Data = new
                    {
                        msg = "ویرایش اطلاعات با موفقیت انجام شد",
                        status = true
                    };
                }
                catch
                {
                    result.Data = new
                    {
                        msg = "ویرایش اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید",
                        status = false
                    };
                }
            }
            else
            {
                result.Data = new
                {
                    msg = "ویرایش اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند",
                    status = false
                };
            }

            return result;
        }
    }
}