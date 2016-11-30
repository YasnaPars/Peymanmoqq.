using BLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class HomeController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "username")]
        public virtual ActionResult SelectUsername(string username)
        {
            return Content(UserSite.SelectName(System.Web.HttpContext.Current.User.Identity.Name), "text/html");
        }

        [ChildActionOnly]
        [OutputCache(Duration = 1800)]
        public virtual ActionResult SelectNotification()
        {
            List<AdminNotificationVM> model = new List<AdminNotificationVM>();
            int tempCount = 0;
            int totalCount = 0;

            model.Add(new AdminNotificationVM
            {
                ClassName = "fa fa-envelope warning",
                Title = "پیام جدید",
                Url = Url.Action(MVC.Admin.Contact.Inbox()),
                Count = tempCount = Contact.SelectNew()
            });

            totalCount += tempCount;

            model.Add(new AdminNotificationVM
            {
                ClassName = "fa fa-shopping-cart danger",
                Title = "درخواست سفارش",
                Url = Url.Action(MVC.Admin.Order.Index()),
                Count = tempCount = Order.SelectNew()
            });

            totalCount += tempCount;

            model.Add(new AdminNotificationVM
            {
                ClassName = "fa fa-comments info",
                Title = "نظرات تایید نشده اخبار",
                Url = Url.Action(MVC.Admin.Comment.Index()),
                Count = tempCount = Comment.SelectNew()
            });

            totalCount += tempCount;

            model.Add(new AdminNotificationVM
            {
                ClassName = "fa fa-comments success",
                Title = "نظرات تایید نشده محصولات",
                Url = Url.Action(MVC.Admin.CommentProduct.Index()),
                Count = tempCount = CommentProduct.SelectNew()
            });

            totalCount += tempCount;

            return PartialView(MVC.Admin.Shared.Views._PartialNotification, new Tuple<List<AdminNotificationVM>, int>(model, totalCount));
        }
    }
}