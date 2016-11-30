using System.Web.Mvc;

namespace PeymanMq.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new
                {
                    controller = MVC.Admin.Home.Name,
                    action = MVC.Admin.Home.ActionNames.Index,
                    id = UrlParameter.Optional
                }
            );
        }
    }
}