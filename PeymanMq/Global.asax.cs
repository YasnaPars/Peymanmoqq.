using BLL;
using System;
using System.Data.Entity;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace PeymanMq
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // تعریف model binder سفارشی
            ModelBinders.Binders.Add(typeof(DateTime), new PersianDateModelBinder());
            // فراخوانی EF Profiler
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            // آغاز کننده بانک اطلاعاتی
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectModel, BLL.Migrations.Configuration>());
            using (var context = new ProjectModel())
            {
                context.Database.Initialize(force: true);
            }
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
            Application["OnlineUsers"] = 0;
            // حذف View Engines اضافی
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        void Session_Start(object sender, EventArgs e)
        {
            if (Request.Cookies["statistic"] == null)
            {
                try
                {
                    HttpCookie statisCookie = new HttpCookie("statistic", "");
                    statisCookie.Expires = DateTime.Now.AddMinutes(10);
                    Response.Cookies.Add(statisCookie);
                }
                catch
                {
                }

                // آمار بازدید
                try
                {
                    Statistic.Insert(Request.Browser.Browser.ToLower());
                }
                catch
                {
                }
            }

            try
            {
                Application.Lock();
                Application["OnlineUsers"] = (int)Application["onlineUsers"] + 1;
                Application.UnLock();
            }
            catch
            {
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            try
            {
                Application.Lock();
                Application["OnlineUsers"] = (int)Application["onlineUsers"] - 1;
                Application.UnLock();
            }
            catch
            {
            }
        }

        // دستورات مربوط به اعتبارسنجی کاربران
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null && authCookie.Value != string.Empty)
                {
                    FormsAuthenticationTicket MyTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    FormsIdentity MyIdentity = new FormsIdentity(MyTicket);
                    Context.User = new GenericPrincipal(MyIdentity, MyTicket.UserData.Split(new char[] { ',' }));
                }
            }
            catch
            {
            }
        }
    }
}