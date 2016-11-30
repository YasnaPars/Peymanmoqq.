using BLL;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class DynamicPartController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            return View(DynamicPart.Select());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(List<DynamicPart> list)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DynamicPart.Update(list);
                    TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                    return RedirectToAction(MVC.Admin.DynamicPart.Index());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>ویرایش اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>ویرایش اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            return View(list);
        }

        [ChildActionOnly]
        public virtual ContentResult Select(string title)
        {
            try
            {
                return Content(DynamicPart.Select(title));
            }
            catch
            {
                return Content("محتوایی یافت نشد.");
            }
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult Update(DynamicPart obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DynamicPart.Update(obj);
                    return Content("ذخیره گردید");
                }
                catch
                {
                    return Content("ویرایش اطلاعات با خطا مواجه شده است. لطفا مجددا تلاش نمایید");
                }
            }
            else
            {
                return Content("خطایی رخ داده است. داده های ورودی صحیح نمی باشد");
            }
        }
    }
}