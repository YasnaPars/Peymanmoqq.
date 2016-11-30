using BLL;
using System;
using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class BaseController : Controller
    {
        public MainLayoutVM model { get; set; }

        public BaseController()
        {
            model = new MainLayoutVM();
            string[] dynamicPartModel = DynamicPart.Select("کارخانه", "دفتر مرکزی", "تلفن", "فکس", "موبایل",
                                                           "ایمیل", "آدرس لوگوی سایت", "لینک فیسبوک", "لینک اینستاگرام",
                                                           "لینک لینکدین", "لینک تلگرام");
            model.Factory = dynamicPartModel[0];
            model.Address = dynamicPartModel[1];
            model.Phone = dynamicPartModel[2];
            model.Fax = dynamicPartModel[3];
            model.Mobile = dynamicPartModel[4];
            model.Email = dynamicPartModel[5];
            model.LogoUrl = dynamicPartModel[6];
            model.FacebookLink = dynamicPartModel[7];
            model.InstagramLink = dynamicPartModel[8];
            model.LinkedinLink = dynamicPartModel[9];
            model.TelegramLink = dynamicPartModel[10];
            model.LastBlogs = BlogJoinBlogCategory.SelectLast();
            model.LastProducts = Product.SelectLast();
            ViewBag.MainLayoutVM = model;
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            DynamicPage dynamicPageModel = DynamicPage.Select(Request.RawUrl);

            if (dynamicPageModel != null)
            {
                ViewBag.MetaKeywords = dynamicPageModel.MetaKeywords;
                ViewBag.MetaDescription = dynamicPageModel.MetaDescription;
                ViewBag.ExtraContent = dynamicPageModel.ExtraContent;
                ViewBag.Title = dynamicPageModel.Title;
            }

            return base.BeginExecuteCore(callback, state);
        }
    }
}