using AutoMapper;
using BLL;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class FileUploadController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            string alert = TempData["alert"] as string;

            if (!string.IsNullOrWhiteSpace(alert))
            {
                ViewBag.Alert = alert;
            }

            return View(new FileUploadInsertVM
            {
                CategoryList = FileUploadCategory.SelectList(null)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(FileUploadInsertVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string path = Server.MapPath("~/Data/Admin");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(model.file.FileName).ReplaceAllChar() + Path.GetExtension(model.file.FileName);

                    for (;;)
                    {
                        if (System.IO.File.Exists(Path.Combine(path, fileName)))
                        {
                            fileName = DateTime.Now.Millisecond + "_" + fileName;
                        }
                        else
                        {
                            break;
                        }
                    }

                    FileUpload tempObj = new FileUpload();
                    tempObj.Title = model.Title;
                    tempObj.RealName = fileName;
                    tempObj.FileUploadTypeID = FileUploadType.Insert(model.file.ContentType.ToLower());
                    tempObj.Size = (float)model.file.ContentLength / 1024;
                    tempObj.Rank = FileUpload.SelectRank(model.FileUploadCategoryID) + 1;
                    tempObj.FileUploadCategoryID = model.FileUploadCategoryID;
                    FileUpload.Insert(tempObj);
                    model.file.SaveAs(Path.Combine(path, fileName));
                    TempData["alert"] = "<div class='alert alert-success alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-check'></i></div><strong>آپلود فایل با موفقیت انجام شد</strong></div>";
                    return RedirectToAction(MVC.Admin.FileUpload.Index());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-times'></i></div><strong>آپلود فایل با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning alert-white rounded fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><div class='icon'><i class='fa fa-warning'></i></div><strong>آپلود فایل با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            model.CategoryList = FileUploadCategory.SelectList(model.FileUploadCategoryID);
            return View(model);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Select(int pageIndex, int pageSize, int? category, int? type)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = FileUpload.Select(pageIndex, pageSize, out total, category, type),
                TotalRows = total
            };

            return result;
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult SelectImage(int pageIndex, int pageSize, int? category)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = FileUpload.SelectImage(pageIndex, pageSize, out total, category),
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

                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Data/Admin"), url)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Data/Admin/" + url));
                    }

                    FileUpload.Delete(id.Value);
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
        public virtual ContentResult DeleteAll(int[] list, string[] urlList)
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                for (int i = 0; i < list.Length; i++)
                {
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Data/Admin"), urlList[i])))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Data/Admin/" + urlList[i]));
                    }

                    FileUpload.Delete(list[i]);
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
        public virtual ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                FileUploadUpdateVM model = Mapper.Map<FileUploadUpdateVM>(FileUpload.Select(id.Value));
                model.CategoryList = FileUploadCategory.SelectList(model.FileUploadCategoryID);
                return PartialView(Views._PartialEdit, model);
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
        public virtual JsonResult Update(FileUploadUpdateVM obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FileUpload.Update(obj);
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
                FileUpload.Update(id, type);
                return Json(true);
            }
            catch
            {
            }

            return Json(false);
        }
    }
}