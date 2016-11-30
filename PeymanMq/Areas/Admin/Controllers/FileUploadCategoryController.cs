using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class FileUploadCategoryController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(FileUploadCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FileUploadCategory.Insert(model);
                    TempData["alert"] = "<div class='alert alert-success alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-check'></i></div><strong>درج اطلاعات با موفقیت انجام شد</strong></div>";
                    return RedirectToAction(MVC.Admin.FileUploadCategory.Index());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-times'></i></div><strong>درج اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-warning'></i></div><strong>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            return View(model);
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
                List = FileUploadCategory.Select(pageIndex, pageSize, out total),
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
                    FileUploadCategory.Delete(id.Value);
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
                return PartialView(Views._PartialEdit, FileUploadCategory.Select(id.Value));
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
        public virtual JsonResult Update(FileUploadCategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FileUploadCategory.Update(obj);
                    return Json(true);
                }
                catch
                {
                }
            }

            return Json(false);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult UpdateRank(int id, string type)
        {
            try
            {
                FileUploadCategory.Update(id, type);
                return Json(true);
            }
            catch
            {
            }

            return Json(false);
        }
    }
}