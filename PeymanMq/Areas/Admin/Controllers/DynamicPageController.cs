using BLL;
using System.Web.Mvc;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class DynamicPageController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            return View(new DynamicPageVM
            {
                List = DynamicPage.SelectList(null),
                DynamicPage = new DynamicPage { MetaKeywords = "پیمان موکت" }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(DynamicPageVM obj)
        {
            DynamicPageVM model = new DynamicPageVM();

            if (ModelState.IsValid)
            {
                try
                {
                    if (obj.BtnDynamicPage == "save")
                    {
                        DynamicPage.Update(obj);
                        model.List = DynamicPage.SelectList(obj.PageID.Value);
                        model.DynamicPage = DynamicPage.Select(obj.PageID.Value);
                        model.PageID = obj.PageID;
                        ViewBag.Alert = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                    }
                    else if (obj.BtnDynamicPage == "delete")
                    {
                        DynamicPage.Delete(obj.PageID.Value);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>حذف اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.DynamicPage.Index());
                    }

                    return View(model);
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>عملیات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>عملیات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            model.List = DynamicPage.SelectList(null);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Select(DynamicPageVM obj)
        {
            DynamicPageVM model = new DynamicPageVM();

            if (ModelState.IsValid)
            {
                try
                {
                    model.List = DynamicPage.SelectList(obj.PageID.Value);
                    model.DynamicPage = DynamicPage.Select(obj.PageID.Value);
                    model.PageID = obj.PageID;
                }
                catch
                {
                    model.List = DynamicPage.SelectList(null);
                }
            }

            return View(Views.Index, model);
        }
    }
}