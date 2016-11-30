using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class SearchController : BaseController
    {
        public virtual ActionResult Index(string keyword)
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult Select(int pageIndex, int pageSize, string keyword)
        {
            JsonResult result = new JsonResult();
            List<ClsSearch> searchResult = new List<ClsSearch>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                foreach (var item in Blog.Select(keyword))
                {
                    ClsSearch temp = new ClsSearch
                    {
                        Url = item.Url != null ? item.Url : Url.Action(MVC.Blog.Details().AddRouteValues(new { id = item.ID, text = item.Title.ReplaceAllChar() })),
                        Title = item.Title,
                        ShortBody = item.ShortBody,
                        CreateDate = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false)
                    };
                    searchResult.Add(temp);
                }
            }

            foreach (var item in Product.Select(keyword))
            {
                ClsSearch temp = new ClsSearch
                {
                    Url = Url.Action(MVC.Product.Details().AddRouteValues(new { id = item.ID, text = item.Title.ReplaceAllChar() })),
                    Title = item.Title,
                    ShortBody = item.ShortBody,
                    CreateDate = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false)
                };
                searchResult.Add(temp);
            }

            result.Data = new
            {
                List = searchResult.Skip((pageIndex - 1) * pageSize).Take(pageSize),
                TotalRows = searchResult.Count()
            };

            return result;
        }
    }
}