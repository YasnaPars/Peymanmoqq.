using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class ErrorController : BaseController
    {
        [Route("Error/{error}")]
        public virtual ActionResult Index(string error)
        {
            switch (error)
            {
                case "401":
                    ViewBag.Title = "خطای 401 دسترسی نامعتبر";
                    ViewBag.ErrorTitle = "دسترسی نامعتبر";
                    ViewBag.ErrorNumber = "خطای 401";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 401 دسترسی نامعتبر; دسترسی نامعتبر; خطای 401";
                    break;
                case "403":
                    ViewBag.Title = "خطای 403 دسترسی غیر مجاز";
                    ViewBag.ErrorTitle = "دسترسی غیر مجاز";
                    ViewBag.ErrorNumber = "خطای 403";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 403 دسترسی غیر مجاز; دسترسی غیر مجاز; خطای 403";
                    break;
                case "404":
                    ViewBag.Title = "خطای 404 صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorTitle = "صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorNumber = "خطای 404";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 404 صفحه مورد نظر پیدا نشد; صفحه مورد نظر پیدا نشد; خطای 404";
                    break;
                case "405":
                    ViewBag.Title = "خطای 405 متد غیر مجاز";
                    ViewBag.ErrorTitle = "متد غیر مجاز";
                    ViewBag.ErrorNumber = "خطای 405";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 405 متد غیر مجاز; متد غیر مجاز; خطای 405";
                    break;
                case "500":
                    ViewBag.Title = "خطای 500 خطای داخلی سرور";
                    ViewBag.ErrorTitle = "خطای داخلی سرور";
                    ViewBag.ErrorNumber = "خطای 500";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 500 خطای داخلی سرور; خطای داخلی سرور; خطای 500";
                    return View("Index500");
                case "503":
                    ViewBag.Title = "خطای 503 سرویس خارج از دسترس می باشد";
                    ViewBag.ErrorTitle = "سرویس خارج از دسترس می باشد";
                    ViewBag.ErrorNumber = "خطای 503";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 503 سرویس خارج از دسترس می باشد; سرویس خارج از دسترس می باشد; خطای 503";
                    break;
                default:
                    ViewBag.Title = "خطای 404 صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorTitle = "صفحه مورد نظر پیدا نشد";
                    ViewBag.ErrorNumber = "خطای 404";
                    ViewBag.MetaKeywords = ViewBag.MetaDescription = "خطای 404 صفحه مورد نظر پیدا نشد; صفحه مورد نظر پیدا نشد; خطای 404";
                    break;
            }

            return View();
        }
    }
}