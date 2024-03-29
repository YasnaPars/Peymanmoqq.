// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace PeymanMq.Areas.Admin.Controllers
{
    public partial class OrderController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OrderController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OrderController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Select()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Select);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Delete()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteAll()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteAll);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult UpdateRank()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.UpdateRank);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UpdateStar()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateStar);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Download()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Download);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OrderController Actions { get { return MVC.Admin.Order; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Order";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Order";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Select = "Select";
            public readonly string Delete = "Delete";
            public readonly string DeleteAll = "DeleteAll";
            public readonly string UpdateRank = "UpdateRank";
            public readonly string UpdateStar = "UpdateStar";
            public readonly string Details = "Details";
            public readonly string Download = "Download";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Select = "Select";
            public const string Delete = "Delete";
            public const string DeleteAll = "DeleteAll";
            public const string UpdateRank = "UpdateRank";
            public const string UpdateStar = "UpdateStar";
            public const string Details = "Details";
            public const string Download = "Download";
        }


        static readonly ActionParamsClass_Select s_params_Select = new ActionParamsClass_Select();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Select SelectParams { get { return s_params_Select; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Select
        {
            public readonly string pageIndex = "pageIndex";
            public readonly string pageSize = "pageSize";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
            public readonly string url = "url";
        }
        static readonly ActionParamsClass_DeleteAll s_params_DeleteAll = new ActionParamsClass_DeleteAll();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteAll DeleteAllParams { get { return s_params_DeleteAll; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteAll
        {
            public readonly string list = "list";
            public readonly string urlList = "urlList";
        }
        static readonly ActionParamsClass_UpdateRank s_params_UpdateRank = new ActionParamsClass_UpdateRank();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateRank UpdateRankParams { get { return s_params_UpdateRank; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateRank
        {
            public readonly string id = "id";
            public readonly string type = "type";
        }
        static readonly ActionParamsClass_UpdateStar s_params_UpdateStar = new ActionParamsClass_UpdateStar();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateStar UpdateStarParams { get { return s_params_UpdateStar; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateStar
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Download s_params_Download = new ActionParamsClass_Download();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Download DownloadParams { get { return s_params_Download; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Download
        {
            public readonly string fileName = "fileName";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Details = "Details";
                public readonly string Index = "Index";
            }
            public readonly string Details = "~/Areas/Admin/Views/Order/Details.cshtml";
            public readonly string Index = "~/Areas/Admin/Views/Order/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OrderController : PeymanMq.Areas.Admin.Controllers.OrderController
    {
        public T4MVC_OrderController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SelectOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int pageIndex, int pageSize);

        [NonAction]
        public override System.Web.Mvc.JsonResult Select(int pageIndex, int pageSize)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Select);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "pageIndex", pageIndex);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "pageSize", pageSize);
            SelectOverride(callInfo, pageIndex, pageSize);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int? id, string url);

        [NonAction]
        public override System.Web.Mvc.JsonResult Delete(int? id, string url)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "url", url);
            DeleteOverride(callInfo, id, url);
            return callInfo;
        }

        [NonAction]
        partial void DeleteAllOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int[] list, string[] urlList);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteAll(int[] list, string[] urlList)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteAll);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "list", list);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlList", urlList);
            DeleteAllOverride(callInfo, list, urlList);
            return callInfo;
        }

        [NonAction]
        partial void UpdateRankOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int id, string type);

        [NonAction]
        public override System.Web.Mvc.JsonResult UpdateRank(int id, string type)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.UpdateRank);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "type", type);
            UpdateRankOverride(callInfo, id, type);
            return callInfo;
        }

        [NonAction]
        partial void UpdateStarOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult UpdateStar(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateStar);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            UpdateStarOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Details(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DownloadOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string fileName);

        [NonAction]
        public override System.Web.Mvc.ActionResult Download(string fileName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Download);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "fileName", fileName);
            DownloadOverride(callInfo, fileName);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
