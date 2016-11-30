using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class StatisticController : AdminAuthorizeController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 900, VaryByParam = "none")]
        public virtual ActionResult Select()
        {
            return PartialView(Views._PartialSummaryStatistic, Statistic.Select());
        }

        [AjaxOnly]
        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult SelectList(int pageIndex, int pageSize)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Statistic.Select(pageIndex, pageSize, out total),
                TotalRows = total
            };

            return result;
        }
    }
}