using BLL;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class LoginController : Controller
    {
        public virtual ActionResult Index(string ReturnUrl)
        {
            return View(new LoginAdminVM() { ReturnUrl = ReturnUrl, RememberStatus = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(LoginAdminVM item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserSite query = UserSite.Select(item.Username, ClsMain.Calculate_Sha1_MD5(item.Password, Encoding.Default));

                    if (query.Status == Status.Active)
                    {
                        if (query.Role.ID != 1)
                        {
                            return RedirectToAction(MVC.Home.Index());
                        }
                        else
                        {
                            DateTime expiration = DateTime.Now.AddMinutes(60);

                            if (item.RememberStatus)
                            {
                                expiration = DateTime.Now.AddDays(1);
                            }

                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, query.Username, DateTime.Now, expiration, false, query.Role.Title, FormsAuthentication.FormsCookiePath);
                            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                            authCookie.Expires = authTicket.Expiration;
                            Response.Cookies.Add(authCookie);

                            try
                            {
                                UserSite.Update(query.Username);
                            }
                            catch
                            {
                            }

                            ViewBag.Alert = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-check sign'></i><strong>ورود موفقیت آمیز بود</strong></div>";

                            if (!string.IsNullOrWhiteSpace(item.ReturnUrl) && Url.IsLocalUrl(item.ReturnUrl) && item.ReturnUrl.Length > 1
                                && item.ReturnUrl.StartsWith("/") && !item.ReturnUrl.StartsWith("//") && !item.ReturnUrl.StartsWith("/\\"))
                            {
                                return Redirect(item.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction(MVC.Admin.Home.Index());
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>اکانت شما مسدود می باشد</strong></div>";
                    }
                }
                catch
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-times-circle sign'></i><strong>نام کاربری یا رمز عبور نادرست است</strong></div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a><i class='fa fa-warning sign'></i><strong>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</strong></div>";
            }

            return View(item);
        }

        [HttpPost]
        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Admin.Login.Index(""));
        }
    }
}