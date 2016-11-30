using AutoMapper;
using BLL;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Controllers
{
    public partial class ProductController : BaseController
    {
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
                List = Product.Select(pageIndex, pageSize, 1, out total, category),
                TotalRows = total
            };

            return result;
        }

        public virtual ActionResult Details(int id)
        {
            return View(Product.Select(id, 1));
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult InsertComment(CommentProductInsertVM model)
        {
            var temp = TempData["Captcha4"];

            if (temp == null || string.IsNullOrWhiteSpace(temp.ToString()) || temp.ToString() != model.Captcha)
            {
                return Json("<div class='alert alert-warning fade in'>حاصل جمع اشتباه می باشد</div>");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CommentProduct obj = Mapper.Map<CommentProduct>(model);
                    obj.ProductID = model.PostID;
                    CommentProduct.Insert(obj);
                    return Json("<div class='alert alert-success fade in'>نظر شما با موفقیت ارسال گردید. بعد از تایید مدیر در سایت نمایش داده می شود</div>");
                }
                catch
                {
                    return Json("<div class='alert alert-danger fade in'>ارسال اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</div>");
                }
            }
            else
            {
                return Json("<div class='alert alert-warning fade in'>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</div>");
            }
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult SelectProduct(int itemID, int? categoryID)
        {
            JsonResult result = new JsonResult();

            try
            {
                result.Data = new
                {
                    List = ProductJoinProductCategory.Select(categoryID.Value, itemID)
                };
            }
            catch
            {
            }

            return result;
        }

        public virtual ActionResult Order()
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            return View(new OrderInsertVM
            {
                OrderDate = DateTime.Now,
                ProductCategoryList = ProductCategory.SelectList(2),
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Order(OrderInsertVM model)
        {
            var temp = TempData["Captcha3"];

            if (temp == null || string.IsNullOrWhiteSpace(temp.ToString()) || temp.ToString() != model.Captcha.Trim())
            {
                ModelState.AddModelError(string.Empty, "لطفا خطاهای بوجود آمده را تصحیح نمایید");
                ModelState.AddModelError("Captcha", "حاصل جمع اشتباه می باشد");
                model.ProductCategoryList = ProductCategory.SelectList(2, model.ProductCategoryID);
                return View(model);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Order obj = Mapper.Map<Order>(model);
                    string path = Server.MapPath("~/Data/DenyUsers");
                    string fileName;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (model.PostedFile != null && model.PostedFile.ContentLength != 0 && model.PostedFile.FileName.Trim() != string.Empty)
                    {
                        fileName = Path.GetFileNameWithoutExtension(model.PostedFile.FileName).ReplaceAllChar() + Path.GetExtension(model.PostedFile.FileName);

                        for (;;)
                        {
                            if (System.IO.File.Exists(Path.Combine(path, fileName)))
                            {
                                fileName = DateTime.Now.Ticks + "_" + fileName;
                            }
                            else
                            {
                                break;
                            }
                        }

                        obj.FileName = fileName;
                        model.PostedFile.SaveAs(Path.Combine(path, fileName));
                    }

                    BLL.Order.Insert(obj);
                    TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>درخواست شما با موفقیت ارسال شد</div>";
                    return RedirectToAction(MVC.Product.Order());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>ارسال اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</div>";
            }

            model.ProductCategoryList = ProductCategory.SelectList(2, model.ProductCategoryID);
            model.HiddenSubItemID = model.ProductID;
            return View(model);
        }

        [ChildActionOnly]
        public virtual ActionResult SelectRate(int itemID)
        {
            ProductRatingVM model = ProductRating.Select(itemID);
            HttpCookie rateCookie;

            try
            {
                if (Request.Cookies["rate_product_" + itemID] == null)
                {
                    rateCookie = new HttpCookie("rate_product_" + itemID);
                }
                else
                {
                    rateCookie = Request.Cookies["rate_product_" + itemID];
                }
            }
            catch
            {
                rateCookie = new HttpCookie("rate_product_" + itemID);
            }

            if (model == null)
            {
                model = new ProductRatingVM
                {
                    Readonly = false,
                    ID = itemID,
                    SumRating = 0,
                    TotalRaters = 0
                };
            }
            else
            {
                if (string.IsNullOrWhiteSpace(rateCookie.Value))
                {
                    model.Readonly = false;
                }
                else
                {
                    model.Readonly = true;
                    model.CurrentRating = Convert.ToByte(rateCookie.Value);
                }
            }

            return PartialView(Views._PartialRating, model);
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult InsertRate(int itemID, byte value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductRating obj = new ProductRating {
                        ProductID = itemID,
                        Rating = value
                    };
                    ProductRating.Insert(obj);
                    HttpCookie rateCookie = new HttpCookie("rate_product_" + itemID);
                    rateCookie.Value = value.ToString();
                    rateCookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(rateCookie);
                    return Json("<small class='alert alert-success fade in'>با تشکر. رای شما ثبت شد</small>");
                }
                catch
                {
                    return Json("<small class='alert alert-danger fade in'>ارسال اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</small>");
                }
            }
            else
            {
                return Json("<small class='alert alert-warning fade in'>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</small>");
            }
        }
    }
}