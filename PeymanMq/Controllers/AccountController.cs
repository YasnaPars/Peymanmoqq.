using BLL;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    [RoutePrefix("Account")]
    public partial class AccountController : BaseController
    {
        [Route("Forget-Password")]
        public virtual ActionResult ForgetPassword()
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
        [Route("Forget-Password")]
        public virtual ActionResult ForgetPassword(UserSiteRecoverPasswordVM obj)
        {
            var temp = TempData["Captcha2"];

            if (temp == null || string.IsNullOrWhiteSpace(temp.ToString()) || temp.ToString() != obj.Captcha.Trim())
            {
                ModelState.AddModelError(string.Empty, "لطفا خطاهای بوجود آمده را تصحیح نمایید");
                ModelState.AddModelError("Captcha", "حاصل جمع اشتباه می باشد");
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string confirmCode = (Guid.NewGuid().ToString().Replace("-", string.Empty) + DateTime.Now.Ticks).ToUpper();

                    if (UserSite.Update(obj.Email, confirmCode) != Status.Active)
                    {
                        ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>شما قادر به انجام این عملیات نیستید. اکانت شما غیر فعال می باشد</div>";
                        return View(obj);
                    }

                    StreamReader sr = new StreamReader(Server.MapPath("~/EmailPattern/ConfirmRecoverPassword.html"));
                    StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                    sr.Close();
                    sb = sb.Replace("@@@siteUrl", ClsMain.SiteUrl).Replace("@@@siteTitle", ClsMain.SiteTitle).Replace("@@@activeLink", new UrlHelper(Request.RequestContext).Action(MVC.Account.RecoverPassword().AddRouteValues(new { key = confirmCode }), "http"))
                        .Replace("@@@footerAddress", ((MainLayoutVM)ViewBag.MainLayoutVM).Address).Replace("@@@footerTell", ((MainLayoutVM)ViewBag.MainLayoutVM).Phone).Replace("@@@footerEmail", ((MainLayoutVM)ViewBag.MainLayoutVM).Email).Replace("@@@logoUrl", ((MainLayoutVM)ViewBag.MainLayoutVM).LogoUrl);
                    ClsMain.SendEmail(Email.Select(), "درخواست رمز عبور جدید", sb, new string[] { obj.Email }, ClsMain.SiteTitle);
                    TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>یک ایمیل تایید به آدرس " + obj.Email + " ارسال شد. لطفا ایمیل خود را بررسی نمایید. ممکن است ایمیل به پوشه spam شما رفته باشد</div>";
                    return RedirectToAction(MVC.Account.ForgetPassword());
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>این ایمیل قبلا ثبت نشده است</div>";
                    return View(obj);
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</div>";
            }

            return View(obj);
        }

        [Route("Recover-Password/{key}")]
        public virtual ActionResult RecoverPassword(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                try
                {
                    string pass = (Guid.NewGuid().ToString().Replace("-", string.Empty)).Substring(0, 6);
                    UserSite obj = UserSite.UpdatePassword(key, ClsMain.Calculate_Sha1_MD5(pass, Encoding.Default));

                    try
                    {
                        StreamReader sr = new StreamReader(Server.MapPath("~/EmailPattern/RecoverPassword.html"));
                        StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                        sr.Close();
                        sb = sb.Replace("@@@siteUrl", ClsMain.SiteUrl).Replace("@@@siteTitle", ClsMain.SiteTitle).Replace("@@@username", obj.Username).Replace("@@@password", pass)
                            .Replace("@@@footerAddress", ((MainLayoutVM)ViewBag.MainLayoutVM).Address).Replace("@@@footerTell", ((MainLayoutVM)ViewBag.MainLayoutVM).Phone).Replace("@@@footerEmail", ((MainLayoutVM)ViewBag.MainLayoutVM).Email).Replace("@@@logoUrl", ((MainLayoutVM)ViewBag.MainLayoutVM).LogoUrl);
                        ClsMain.SendEmail(Email.Select(), "نام کاربری و رمز عبور", sb, new string[] { obj.Email }, ClsMain.SiteTitle);
                    }
                    catch
                    {
                    }

                    ViewBag.Username = obj.Username;
                    ViewBag.Password = pass;
                    return View();
                }
                catch
                {
                    return Redirect("/");
                }
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}