using BLL;
using System.Web.Mvc;
using System.Web.UI;

namespace PeymanMq.Controllers
{
    public partial class CertificateController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual JsonResult Select(int pageIndex, int pageSize)
        {
            JsonResult result = new JsonResult();
            int total;

            result.Data = new
            {
                List = Certificate.Select(pageIndex, pageSize, 1, out total),
                TotalRows = total
            };

            return result;
        }
    }
}