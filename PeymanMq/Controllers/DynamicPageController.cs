using BLL;
using System.Web;
using System.Web.Mvc;

namespace PeymanMq.Controllers
{
    public partial class DynamicPageController : BaseController
    {
        public virtual ActionResult Index(string pageName)
        {
            DynamicPage model = DynamicPage.Select("/page/" + pageName);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                throw new HttpException(404, "Page Not Found");
            }
        }
    }
}