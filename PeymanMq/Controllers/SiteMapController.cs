using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class SiteMapController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}