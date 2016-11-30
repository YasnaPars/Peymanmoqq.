using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class SliderController : AdminAuthorizeController
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
                ViewBag.Title = "ویرایش اسلایدر";
                return View(Slider.Select(id.Value));
            }
            else
            {
                ViewBag.Title = "اضافه کردن اسلایدر";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Update(Slider obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ID != 0)
                {
                    try
                    {
                        Slider.Update(obj);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.Slider.Update());
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
                        Slider.Insert(obj);
                        TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>درج اطلاعات با موفقیت انجام شد</strong></div>";
                        return RedirectToAction(MVC.Admin.Slider.Update());
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
        public virtual JsonResult Select(int pageIndex, int pageSize)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Slider.Select(pageIndex, pageSize, out total),
                TotalRows = total
            };

            return result;
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult UpdateRank(int id, string type)
        {
            try
            {
                Slider.Update(id, type);
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
        public virtual JsonResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Slider.Delete(id.Value);
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
                Slider.Delete(list);
                return Content("ok");
            }
            catch
            {
                return Content(string.Empty);
            }
        }
    }
}