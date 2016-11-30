using BLL;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class ProductController : AdminAuthorizeController
    {
        public virtual ActionResult Update(int? id)
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            if (id.HasValue)
            {
                Product model = Product.Select(id.Value, 2);
                model.UserSiteCategoryList = UserSite.SelectList(model.UserSiteID != null ? model.UserSiteID.Value : 0);
                model.CategoryList = ProductJoinProductCategory.Select(id.Value);
                ViewBag.Title = "ویرایش محصول";
                return View(model);
            }
            else
            {
                ViewBag.Title = "اضافه کردن محصول";
                return View(new Product
                {
                    UserSiteCategoryList = UserSite.SelectList(),
                    CategoryList = new int[] { },
                    MetaKeywords = "پیمان موکت",
                    CatalogTitle = "دانلود کاتالوگ"
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Update(Product obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ID != 0)
                {
                    try
                    {
                        Product.Update(obj);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.Product.Update());
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>اخطار: این رکورد توسط کاربر دیگری ویرایش و یا حذف شده است. دوباره تلاش نمایید</strong></div>";
                    }
                    catch
                    {
                        ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>ویرایش اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                    }
                }
                else
                {
                    try
                    {
                        Product.Insert(obj);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>درج اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.Product.Update());
                    }
                    catch
                    {
                        ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>درج اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                    }
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            obj.UserSiteCategoryList = UserSite.SelectList(obj.UserSiteID != null ? obj.UserSiteID.Value : 0);
            obj.CategoryList = ProductJoinProductCategory.Select(obj.ID);
            return View(obj);
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Select(int pageIndex, int pageSize, int? category)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Product.Select(pageIndex, pageSize, 2, out total, category),
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
                    Product.Delete(id.Value);
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
        public virtual ActionResult DeleteAll(int[] list)
        {
            try
            {
                Product.Delete(list);
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
        public virtual JsonResult UpdateRank(int id, string type, int? category)
        {
            try
            {
                Product.Update(id, type, category);
                return Json(true);
            }
            catch
            {
            }

            return Json(false);
        }

        public virtual ActionResult Details(int id)
        {
            return View(Product.Select(id, 2));
        }
    }
}