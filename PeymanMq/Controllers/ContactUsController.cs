using AutoMapper;
using BLL;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    [RoutePrefix("Contact-Us")]
    public partial class ContactUsController : BaseController
    {
        [Route("")]
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
        [Route("")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(ContactInsertVM model)
        {
            var temp = TempData["Captcha1"];

            if (temp == null || string.IsNullOrWhiteSpace(temp.ToString()) || temp.ToString() != model.Captcha.Trim())
            {
                ModelState.AddModelError(string.Empty, "لطفا خطاهای بوجود آمده را تصحیح نمایید");
                ModelState.AddModelError("Captcha", "حاصل جمع اشتباه می باشد");
                return View(model);
            } 

            if (ModelState.IsValid)
            {
                bool sw1, sw2;
                Contact obj = Mapper.Map<Contact>(model);
                sw1 = Contact.Insert(obj);
                StreamReader sr = new StreamReader(Server.MapPath("~/EmailPattern/ContactUs.html"));
                StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                sr.Close();
                sb = sb.Replace("@@@siteUrl", ClsMain.SiteUrl).Replace("@@@siteTitle", ClsMain.SiteTitle).Replace("@@@subject", model.Subject)
                     .Replace("@@@date", model.Date.ToPersianDate("dddd d MMMM yyyy - HH:mm", false)).Replace("@@@fullName", model.FullName)
                     .Replace("@@@email", model.Email).Replace("@@@phone", model.Phone).Replace("@@@mobile", model.Mobile).Replace("@@@body", model.Body)
                     .Replace("@@@footerAddress", ((MainLayoutVM)ViewBag.MainLayoutVM).Address).Replace("@@@footerTell", ((MainLayoutVM)ViewBag.MainLayoutVM).Phone).Replace("@@@footerEmail", ((MainLayoutVM)ViewBag.MainLayoutVM).Email).Replace("@@@logoUrl", ((MainLayoutVM)ViewBag.MainLayoutVM).LogoUrl);
                string[] toEmails = Email.SelectArray("gmail");
                sw2 = ClsMain.SendEmail(Email.Select(), "پیام از طریق سایت", sb, toEmails, ClsMain.SiteTitle);

                if (sw1 || sw2)
                {
                    TempData["alert"] = "<div class='alert alert-success fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>پیام شما با موفقیت ارسال شد</div>";
                    return RedirectToAction(MVC.ContactUs.Index());
                }
                else
                {
                    ViewBag.Alert = "<div class='alert alert-danger fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>ارسال اطلاعات با مشکل مواجه شده است. لطفا مجددا تلاش نمایید</div>";
                }
            }
            else
            {
                ViewBag.Alert = "<div class='alert alert-warning fade in'><a class='close' href='#' title='بستن' aria-label='close' data-dismiss='alert'>×</a>ارسال اطلاعات با مشکل مواجه شده است. داده های ورودی صحیح نمی باشند</div>";
            }

            return View(model);
        }
    }
}