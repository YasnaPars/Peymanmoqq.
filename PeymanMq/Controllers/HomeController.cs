using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}