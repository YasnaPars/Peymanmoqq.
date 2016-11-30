using BLL;
using System.Web.Mvc;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class ErrorController : AdminAuthorizeController
    {
        public virtual ActionResult Index(string id)
        {
            switch (id)
            {
                case "401":
                    ViewBag.Title = "خطای 401 دسترسی نامعتبر";
                    ViewBag.ErrorTitle = "دسترسی نامعتبر";
                    ViewBag.ErrorNumber = "401";
                    break;
                case "403":
                    ViewBag.Title = "خطای 403 دسترسی غیر مجاز";
                    ViewBag.ErrorTitle = "دسترسی غیر مجاز";
                    ViewBag.ErrorNumber = "403";
                    break;
                case "404":
                    ViewBag.Title = "خطای 404 صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorTitle = "صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorNumber = "404";
                    break;
                case "405":
                    ViewBag.Title = "خطای 405 متد غیر مجاز";
                    ViewBag.ErrorTitle = "متد غیر مجاز";
                    ViewBag.ErrorNumber = "405";
                    break;
                case "500":
                    ViewBag.Title = "خطای 500 خطای داخلی سرور";
                    ViewBag.ErrorTitle = "خطای داخلی سرور";
                    ViewBag.ErrorNumber = "500";
                    break;
                case "503":
                    ViewBag.Title = "خطای 503 سرویس خارج از دسترس می باشد";
                    ViewBag.ErrorTitle = "سرویس خارج از دسترس می باشد";
                    ViewBag.ErrorNumber = "503";
                    break;
                default:
                    ViewBag.Title = "خطای 404 صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorTitle = "صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorNumber = "404";
                    break;
            }

            return View();
        }
    }
}