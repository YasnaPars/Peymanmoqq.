using AutoMapper;
using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Controllers
{
    public partial class BlogController : BaseController
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
                List = Blog.Select(pageIndex, pageSize, 1, out total, category),
                TotalRows = total
            };

            return result;
        }

        public virtual ActionResult Details(int id)
        {
            return View(Blog.Select(id, 1));
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult InsertComment(CommentInsertVM model)
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
                    Comment obj = Mapper.Map<Comment>(model);
                    obj.BlogID = model.PostID;
                    Comment.Insert(obj);
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
    }
}