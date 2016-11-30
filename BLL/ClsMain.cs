using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.WebPages;

namespace BLL
{
    // مدل بخش های داینامیک در مسترپیج کاربران
    public class MainLayoutVM
    {
        public string Factory { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string TelegramLink { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string LinkedinLink { get; set; }

        public string LogoUrl { get; set; }

        [Display(Name = "آخرین اخبار")]
        public IList<PostJoinPostCategoryTopVM> LastBlogs { get; set; }

        [Display(Name = "آخرین محصولات")]
        public IList<PostJoinPostCategoryTopVM> LastProducts { get; set; }
    }

    // مدل اعلانات در مسترپیج مدیر
    public class AdminNotificationVM
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string ClassName { get; set; }

        public int Count { get; set; }
    }

    // اجازه دسترسی به نقش ادمین
    [Authorize(Roles = "admin")]
    public abstract class AdminAuthorizeController : Controller
    {
    }

    public enum Status : byte
    {
        [Display(Name = "فعال")]
        Active = 0,

        [Display(Name = "غیر فعال")]
        DeActive = 1,

        [Display(Name = "منتظر تایید")]
        OnProgress = 2
    }

    public enum RequestStatus : byte
    {
        [Display(Name = "بررسی شد")]
        Send = 0,

        [Display(Name = "منتظر تایید")]
        OnProgress = 1
    }

    public enum Gender : byte
    {
        [Display(Name = "مرد")]
        Male = 0,

        [Display(Name = "زن")]
        Female = 1
    }

    public enum Married : byte
    {
        [Display(Name = "مجرد")]
        NotMarried = 0,

        [Display(Name = "متاهل")]
        Married = 1
    }

    public enum Education : byte
    {
        [Display(Name = "سیکل")]
        Sikl = 0,

        [Display(Name = "دیپلم")]
        Diplom = 1,

        [Display(Name = "لیسانس")]
        Lisans = 2,

        [Display(Name = "فوق لیسانس")]
        FogheLisans = 3,

        [Display(Name = "دکتری")]
        Doktor = 4
    }

    public enum YesNo : byte
    {
        [Display(Name = "خیر")]
        No = 0,

        [Display(Name = "بله")]
        Yes = 1
    }

    public enum Quality : byte
    {
        [Display(Name = "عالی")]
        Aali = 0,

        [Display(Name = "خوب")]
        Khoob = 1,

        [Display(Name = "متوسط")]
        Motavaset = 2,

        [Display(Name = "ضعیف")]
        Zaeif = 3
    }

    public class ClsMain
    {
        public static string SiteTitle { get; set; } = "پیمان موکت";

        public static string SiteUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.Host.ToLower().Replace("www.", "");
            }
        }

        // رمز نگاری
        public static string Calculate_Sha1_MD5(string text, Encoding enc)
        {
            StringBuilder sBuilder = new StringBuilder();

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            byte[] buffer = enc.GetBytes(sBuilder.ToString());
            SHA1CryptoServiceProvider cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");
        }

        // ارسال ایمیل
        public static bool SendEmail(List<Email> emails, string title, StringBuilder body, string[] toEmail, string siteTitle, List<Attachment> files = null)
        {
            bool result = false;
            MailMessage mm = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            try
            {
                mm.BodyEncoding = Encoding.UTF8;
                mm.SubjectEncoding = Encoding.UTF8;
                mm.Subject = title;
                mm.Body = body.ToString();
                mm.IsBodyHtml = true;
                // اولویت ایمیل را افزایش می دهیم و در نتیجه امکان کمی دارد که به پوشه ی اسپم ها برود
                mm.Priority = MailPriority.High;

                // به معنای گیرنده اصلی ایمیل میباشد To
                // میباشد و زمانی از آن استفاده می شود که بخواهیم یک کپی از ایمیل را برای شخص دیگری بفرستیم Carbon Copy مخفف CC
                // متوجه ارسال ایمیل برای شخص سوم نشوند CC و To میباشد و زمانی از آن استفاده می شود که بخواهیم یک کپی از ایمیل را برای شخصی بفرستیم به صورتی که Blind Carbon Copy مخفف Bcc
                // خواهد شد To و CC متوجه ارسال ایمیل به BCC اما

                foreach (var item in toEmail)
                {
                    mm.Bcc.Add(new MailAddress(item));
                }

                if (files != null && files.Any())
                {
                    foreach (var item in files)
                    {
                        mm.Attachments.Add(item);
                    }
                }

                foreach (var item in emails)
                {
                    mm.From = new MailAddress(item.Username, siteTitle, Encoding.UTF8);
                    smtp.Host = item.Host;
                    smtp.Port = item.Port;
                    smtp.EnableSsl = item.Ssl;
                    // مجوز پیش فرض را غیرفعال می کنیم و در خط بعد خودمان بهش مجوز میدیم
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(item.Username, item.Password);

                    try
                    {
                        smtp.Send(mm);
                        result = true;
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            finally
            {
                mm.Dispose();
                smtp.Dispose();
            }

            return result;
        }
    }

    public static class ClsExtensionMethods
    {
        public static string ReplaceAllChar(this string str)
        {
            Regex pattern = new Regex("[&*<>\"|./\\:+% ]");
            return pattern.Replace(str.Trim(), "-");
        }

        // تقویم شمسی به همراه محاسبه ی اختلاف زمان رخدادی در گذشته با زمان فعلی
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;

        public static string ToPersianDate(this DateTime dateTime, string pattern, bool checkRelative)
        {
            string persianDate = new PersianDateTime(dateTime).ToString(pattern);

            if (checkRelative)
            {
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
                double totalSeconds = Math.Abs(ts.TotalSeconds);

                if (totalSeconds < 1 * MINUTE)
                {
                    return (ts.Seconds < 10 ? "لحظه ای قبل" : ts.Seconds + " ثانیه قبل") + " - " + persianDate;
                }

                else if (totalSeconds < 60 * MINUTE)
                {
                    return ts.Minutes + " دقیقه قبل" + " - " + persianDate;
                }

                else if (totalSeconds < 24 * HOUR)
                {
                    return ts.Hours + " ساعت قبل" + " - " + persianDate;
                }

                else if (totalSeconds < 30 * DAY)
                {
                    double hours = ts.TotalHours % 24;
                    return (hours > 23 || hours < 1 ? Math.Round(ts.TotalDays) + " روز قبل" : ts.Days + " روز و " + Math.Round(hours) + " ساعت قبل") + " - " + persianDate;
                }

                else if (totalSeconds < 12 * MONTH)
                {
                    double days = ts.TotalDays % 30;
                    return (days > 29 || days < 1 ? Math.Round(ts.TotalDays / 30) + " ماه قبل" : Math.Round(ts.TotalDays / 30) + " ماه و " + Math.Round(days) + " روز قبل") + " - " + persianDate;
                }
                else
                {
                    double months = Math.Floor(ts.TotalDays / 30);
                    return (months % 12 == 0 ? (months / 12 + "  سال قبل") : Math.Floor(months / 12) + " سال و " + (months - (12 * Math.Floor(months / 12))) + " ماه قبل ") + " - " + persianDate;
                }
            }
            else
            {
                return persianDate;
            }
        }

        // نمایش خصوصیت Display برای Enum
        public static string DisplayName(this Status value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this RequestStatus value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this Education value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this Gender value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this Married value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this YesNo value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static string DisplayName(this Quality value)
        {
            Type enumType = value.GetType();
            MemberInfo member = enumType.GetMember(Enum.GetName(enumType, value))[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        // اضافه کردن کلاس active به تگ های li
        public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "active")
        {
            ViewContext viewContext = html.ViewContext;

            if (viewContext.Controller.ControllerContext.IsChildAction)
            {
                viewContext = html.ViewContext.ParentActionViewContext;
            }

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (string.IsNullOrEmpty(actions))
            {
                actions = currentAction;
            }

            if (string.IsNullOrEmpty(controllers))
            {
                controllers = currentController;
            }

            string[] acceptedActions = actions.ToLower().Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.ToLower().Trim().Split(',').Distinct().ToArray();
            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ? cssClass : string.Empty;
        }

        // html helper سفارشی
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, object routeValues, string imagePath, string alternateText = "", object imageHtmlAttributes = null, object anchorHtmlAttributes = null)
        {
            UrlHelper url = new UrlHelper(html.ViewContext.RequestContext);

            TagBuilder imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alternateText);
            imgBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(imageHtmlAttributes));
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            TagBuilder anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.MergeAttribute("target", "_blank");
            anchorBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(anchorHtmlAttributes));
            anchorBuilder.InnerHtml = imgHtml;
            return MvcHtmlString.Create(anchorBuilder.ToString(TagRenderMode.Normal));
        }

        // کش کردن اطلاعات
        public static void CacheInsert(this HttpContextBase httpContext, string key, object data, int durationMinutes)
        {
            if (data == null)
            {
                return;
            }

            httpContext.Cache.Add(key, data, null, DateTime.Now.AddMinutes(durationMinutes), TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
        }

        public static T CacheRead<T>(this HttpContextBase httpContext, string key)
        {
            var data = httpContext.Cache[key];

            if (data != null)
            {
                return (T)data;
            }
            else
            {
                return default(T);
            }
        }

        public static void InvalidateCache(this HttpContextBase httpContext, string key)
        {
            httpContext.Cache.Remove(key);
        }

        // برای زمانی که رکوردی یافت نشود و ارور Sequence contains no elements را می دهند
        public static T MinOrDefault<T>(this IQueryable<T> source, T defaultValue)
        {
            try
            {
                return source.Min();
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T MaxOrDefault<T>(this IQueryable<T> source, T defaultValue)
        {
            try
            {
                return source.Max();
            }
            catch
            {
                return defaultValue;
            }
        }
    }

    // فیلتر سفارشی برای تشخیص دادن اینکه که آیا درخواست رسیده از طرف Jquery Ajax صادر شده است یا خیر
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                throw new InvalidOperationException("این عملیات از طریق ایجکس قابل دسترسی می باشد.");
            }
        }
    }

    // اعتبارسنجی فایل
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] validTypes = { "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "video/3gpp", "application/x-shockwave-flash", "application/pdf", "application/octect-stream", "application/x-troff-msvideo", "video/avi", "video/msvideo", "video/x-msvideo", "image/bmp", "video/x-flv", "image/png", "image/gif", "image/jpeg", "image/pjpeg", "video/x-ms-wmv", "video/mpeg", "video/mp4", "application/zip", "application/octet-stream", "application/x-rar-compressed", "audio/mpeg3", "audio/wav", "audio/x-wav", "audio/mpeg", "video/quicktime" };
            string[] validExtensions = { ".doc", ".docx", ".3gp", ".swf", ".pdf", ".avi", ".bmp", ".flv", ".png", ".gif", ".jpg", ".jpeg", ".wmv", ".mpeg", ".mp4", ".zip", ".rar", ".mp3", ".wav", ".mov" };
            int maxContentLength = 1024 * 1024 * 20; //20 MB
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength == 0 || file.FileName.Trim() == string.Empty)
            {
                ErrorMessage = "آپلود فایل با مشکل مواجه شد. لطفا مجددا سعی نمایید";
                return false;
            }

            if (Array.IndexOf(validTypes, file.ContentType.ToLower()) > -1)
            {
                if (validExtensions.Contains(Path.GetExtension(file.FileName.ToLower())))
                {
                    if (file.ContentLength > 0 && file.ContentLength <= maxContentLength)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "حداکثر حجم مجاز برای آپلود " + (maxContentLength / 1024 / 1024) + "MB می باشد";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "پسوند فایل های مجاز: " + string.Join(", ", validExtensions);
                    return false;
                }
            }
            else
            {
                ErrorMessage = "فرمت فایل مناسب نیست";
                return false;
            }
        }
    }

    // اعتبارسنجی تصاویر
    public class ValidateImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] validTypes = { "image/bmp", "image/png", "image/gif", "image/jpeg", "image/pjpeg" };
            string[] validExtensions = { ".bmp", ".png", ".gif", ".jpg", ".jpeg" };
            int maxContentLength = 1024 * 500; //500 KB
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength == 0 || file.FileName.Trim() == string.Empty)
            {
                return true;
            }

            if (Array.IndexOf(validTypes, file.ContentType.ToLower()) > -1)
            {
                if (validExtensions.Contains(Path.GetExtension(file.FileName.ToLower())))
                {
                    if (file.ContentLength > 0 && file.ContentLength <= maxContentLength)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "حداکثر حجم مجاز برای آپلود " + (maxContentLength / 1024) + "KB می باشد";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "پسوند فایل های مجاز: " + string.Join(", ", validExtensions);
                    return false;
                }
            }
            else
            {
                ErrorMessage = "فرمت فایل مناسب نیست";
                return false;
            }
        }
    }

    // اعتبارسنجی تکست
    public class ValidateWordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] validTypes = { "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf", "application/octect-stream" };
            string[] validExtensions = { ".doc", ".docx", ".pdf" };
            int maxContentLength = 1024 * 1024 * 1; //1 MB
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength == 0 || file.FileName.Trim() == string.Empty)
            {
                return true;
            }

            if (Array.IndexOf(validTypes, file.ContentType.ToLower()) > -1)
            {
                if (validExtensions.Contains(Path.GetExtension(file.FileName.ToLower())))
                {
                    if (file.ContentLength > 0 && file.ContentLength <= maxContentLength)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "حداکثر حجم مجاز برای آپلود " + (maxContentLength / 1024 / 1024) + "MB می باشد";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "پسوند فایل های مجاز: " + string.Join(", ", validExtensions);
                    return false;
                }
            }
            else
            {
                ErrorMessage = "فرمت فایل مناسب نیست";
                return false;
            }
        }
    }

    // اجباری کردن انتخاب چک باکس سمت کاربر
    public class BooleanRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "booleanrequired" // نام متدی خواهد بود که در سمت کلاینت، کار بررسی اعتبار داده‌ها را به عهده خواهد گرفت
            };
        }
    }

    // ساختار xml مرتبط با RSS و Sitemap
    public class PostToXML
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime? PublishDate { get; set; }
    }

    // نتایج جستجو
    public class ClsSearch
    {
        public string Title { get; set; }

        public string ShortBody { get; set; }

        public string Url { get; set; }

        public string CreateDate { get; set; }
    }

    // سفارشی سازی model binder پیش فرض ASP.NET MVC برای فیلد تاریخ
    public class PersianDateModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState { Value = valueResult };
            object actualValue = null;

            try
            {
                var parts = valueResult.AttemptedValue.Split('/'); //ex. 1391/1/19

                if (parts.Length != 3)
                {
                    return null;
                }

                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);
                actualValue = new DateTime(year, month, day, new PersianCalendar());
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }

    // Create an HTML tree from a resursive collection of items
    public class TreeView<T> : IHtmlString
    {
        private readonly HtmlHelper _html;
        private readonly IEnumerable<T> _items = Enumerable.Empty<T>();
        private Func<T, string> _displayProperty = item => item.ToString();
        private Func<T, IEnumerable<T>> _childrenProperty;
        private string _emptyContent = "No children";
        private IDictionary<string, object> _htmlAttributes = new Dictionary<string, object>();
        private IDictionary<string, object> _childHtmlAttributes = new Dictionary<string, object>();
        private Func<T, HelperResult> _itemTemplate;

        public TreeView(HtmlHelper html, IEnumerable<T> items)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            _html = html;
            _items = items;
            // The ItemTemplate will default to rendering the DisplayProperty
            _itemTemplate = item => new HelperResult(writer => writer.Write(_displayProperty(item)));
        }

        /// <summary>
        /// The property which will display the text rendered for each item
        /// </summary>
        public TreeView<T> ItemText(Func<T, string> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            _displayProperty = selector;
            return this;
        }

        /// <summary>
        /// The template used to render each item in the tree view
        /// </summary>
        public TreeView<T> ItemTemplate(Func<T, HelperResult> itemTemplate)
        {
            if (itemTemplate == null)
            {
                throw new ArgumentNullException("itemTemplate");
            }

            _itemTemplate = itemTemplate;
            return this;
        }

        /// <summary>
        /// The property which returns the children items
        /// </summary>
        public TreeView<T> Children(Func<T, IEnumerable<T>> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            _childrenProperty = selector;
            return this;
        }

        /// <summary>
        /// Content displayed if the list is empty
        /// </summary>
        public TreeView<T> EmptyContent(string emptyContent)
        {
            if (emptyContent == null)
            {
                throw new ArgumentNullException("emptyContent");
            }

            _emptyContent = emptyContent;
            return this;
        }

        /// <summary>
        /// HTML attributes appended to the root ul node
        /// </summary>
        public TreeView<T> HtmlAttributes(object htmlAttributes)
        {
            HtmlAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return this;
        }

        /// <summary>
        /// HTML attributes appended to the root ul node
        /// </summary>
        public TreeView<T> HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            _htmlAttributes = htmlAttributes;
            return this;
        }

        /// <summary>
        /// HTML attributes appended to the children items
        /// </summary>
        public TreeView<T> ChildrenHtmlAttributes(object htmlAttributes)
        {
            ChildrenHtmlAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return this;
        }

        /// <summary>
        /// HTML attributes appended to the children items
        /// </summary>
        public TreeView<T> ChildrenHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null)
            {
                throw new ArgumentNullException("htmlAttributes");
            }

            _childHtmlAttributes = htmlAttributes;
            return this;
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public void Render()
        {
            var writer = _html.ViewContext.Writer;

            using (var textWriter = new HtmlTextWriter(writer))
            {
                textWriter.Write(ToString());
            }
        }

        private void ValidateSettings()
        {
            if (_childrenProperty == null)
            {
                throw new InvalidOperationException("You must call the Children() method to tell the tree view how to find child items");
            }
        }

        public override string ToString()
        {
            ValidateSettings();
            var listItems = _items.ToList();
            var ul = new TagBuilder("ul");
            ul.MergeAttributes(_htmlAttributes);

            if (listItems.Count == 0)
            {
                var li = new TagBuilder("li")
                {
                    InnerHtml = _emptyContent
                };

                ul.InnerHtml += li.ToString();
            }

            foreach (var item in listItems)
            {
                BuildNestedTag(ul, item, _childrenProperty);
            }

            return ul.ToString();
        }

        private void AppendChildren(TagBuilder parentTag, T parentItem, Func<T, IEnumerable<T>> childrenProperty)
        {
            var children = childrenProperty(parentItem);

            if (children == null || !children.Any())
            {
                return;
            }

            var innerUl = new TagBuilder("ul");
            innerUl.MergeAttributes(_childHtmlAttributes);

            foreach (var item in children)
            {
                BuildNestedTag(innerUl, item, childrenProperty);
            }

            parentTag.InnerHtml += innerUl.ToString();
        }

        private void BuildNestedTag(TagBuilder parentTag, T parentItem, Func<T, IEnumerable<T>> childrenProperty)
        {
            var li = GetLi(parentItem);
            parentTag.InnerHtml += li.ToString(TagRenderMode.StartTag);
            AppendChildren(li, parentItem, childrenProperty);
            parentTag.InnerHtml += li.InnerHtml + li.ToString(TagRenderMode.EndTag);
        }

        private TagBuilder GetLi(T item)
        {
            var li = new TagBuilder("li")
            {
                InnerHtml = _itemTemplate(item).ToHtmlString()
            };

            return li;
        }
    }

    // نگاشت ViewModel به Model
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ContactInsertVM, Contact>();
                cfg.CreateMap<FileUpload, FileUploadUpdateVM>();
                cfg.CreateMap<CommentInsertVM, Comment>();
                cfg.CreateMap<CommentProductInsertVM, CommentProduct>();
                cfg.CreateMap<DynamicMenuInsertVM, DynamicMenu>().ReverseMap();
                cfg.CreateMap<OrderInsertVM, Order>();
            });
        }
    }
}