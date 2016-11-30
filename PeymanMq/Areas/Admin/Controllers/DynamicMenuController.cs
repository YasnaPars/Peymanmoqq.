using AutoMapper;
using BLL;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class DynamicMenuController : AdminAuthorizeController
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
                DynamicMenu obj = DynamicMenu.SelectSingle(id.Value);
                DynamicMenuInsertVM model = Mapper.Map<DynamicMenuInsertVM>(obj);
                model.ReadyPages = CreateReadyPage();
                model.HiddenSubMenuID = model.ID;
                ViewBag.Title = "ویرایش صفحه";
                return View(model);
            }
            else
            {
                ViewBag.Title = "اضافه کردن صفحه";

                return View(new DynamicMenuInsertVM
                {
                    ReadyPages = CreateReadyPage()
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Update(DynamicMenuInsertVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID != 0)
                {
                    try
                    {
                        DynamicMenu.Update(model);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.DynamicMenu.Update());
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
                        DynamicMenu obj = Mapper.Map<DynamicMenu>(model);
                        DynamicMenu.Insert(model.ParentID, model.SubMenuID, obj);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>درج اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.DynamicMenu.Update());
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

            model.ReadyPages = CreateReadyPage();
            model.HiddenSubMenuID = model.SubMenuID;
            return View(model);
        }

        public virtual ActionResult Index()
        {
            return View(DynamicMenu.Select(2));
        }

        [NonAction]
        public string CreateReadyPage()
        {
            StringBuilder sb = new StringBuilder();
            string pattern = "<div class='alert-info col-sm-6'>##Text##</div>";
            sb.Append(pattern.Replace("##Text##", "'/' : صفحه اصلی"));
            sb.Append(pattern.Replace("##Text##", "'blog' : اخبار"));

            foreach (var item in BlogCategory.SelectString())
            {
                sb.Append(pattern.Replace("##Text##", item));
            }

            foreach (var item in DynamicPage.SelectString())
            {
                sb.Append(pattern.Replace("##Text##", item));
            }

            sb.Append(pattern.Replace("##Text##", "'productcategory' : محصولات"));

            foreach (var item in ProductCategory.SelectString())
            {
                sb.Append(pattern.Replace("##Text##", item));
            }

            sb.Append(pattern.Replace("##Text##", "'product/order' : ارسال سفارش"));
            sb.Append(pattern.Replace("##Text##", "'certificate' : گواهینامه ها"));
            sb.Append(pattern.Replace("##Text##", "'search' : جستجو"));
            sb.Append(pattern.Replace("##Text##", "'contact-us' : تماس با ما"));
            sb.Append(pattern.Replace("##Text##", "'sitemap' : نقشه سایت"));
            sb.Append(pattern.Replace("##Text##", "'rss' : خبرخوان"));
            return sb.ToString();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult SelectMenu(int subMenuID, int? parentID)
        {
            JsonResult result = new JsonResult();

            try
            {
                result.Data = new
                {
                    List = DynamicMenu.SelectList(subMenuID, parentID)
                };
            }
            catch
            {
            }

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
                    DynamicMenu.Delete(id.Value);
                    return Json(true);
                }
            }
            catch
            {
            }

            return Json(false);
        }
    }
}