using BLL;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class EditProfileController : AdminAuthorizeController
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
        public virtual ActionResult Index(LoginChangePasswordVM user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserSite.Update(User.Identity.Name, ClsMain.Calculate_Sha1_MD5(user.OldPassword, Encoding.Default), ClsMain.Calculate_Sha1_MD5(user.NewPassword, Encoding.Default));
                    TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ویرایش اطلاعات با موفقیت انجام شد</strong></div>";
                    return RedirectToAction(MVC.Admin.EditProfile.Index());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times sign'></i><strong>رمز عبور قبلی اشتباه می باشد</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            ModelState.Remove(user.OldPassword);
            return View(user);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ContentResult Update(Email item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Email.Update(item);
                    return Content("<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><strong>ویرایش اطلاعات " + item.Username + " با موفقیت انجام شد</strong></div>");
                }
                catch
                {
                    return Content("<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><strong>ویرایش اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</strong></div>");
                }
            }
            else
            {
                return Content("<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><strong>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>");
            }
        }
    }
}