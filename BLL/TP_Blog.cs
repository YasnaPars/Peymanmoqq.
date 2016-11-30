using HtmlCleaner;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    // جدول اخبار
    [Table("TP_Blog")]
    public partial class Blog
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "چکیده")]
        public string ShortBody { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن اصلی")]
        public string Body { get; set; }

        [DataType(DataType.Url, ErrorMessage = "یک آدرس اینترنتی را وارد کنید")]
        [Display(Name = "لینک مقصد")]
        public string Url { get; set; }

        [ForeignKey("FileUploadID")]
        public virtual FileUpload FileUpload { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "تصویر")]
        public int? FileUploadID { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [DisplayFormat(NullDisplayText = "پیمان موکت")]
        [Display(Name = "منبع")]
        public string Source { get; set; }

        [DataType(DataType.Url, ErrorMessage = "یک آدرس اینترنتی را وارد کنید")]
        [DisplayFormat(NullDisplayText = "http://www.peymanmq.com")]
        [Display(Name = "لینک منبع")]
        public string SourceUrl { get; set; }

        [RegularExpression("([0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(0, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "تعداد بازدید")]
        public int VisitCount { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("UserSiteID")]
        public virtual UserSite UserSite { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "نویسنده")]
        public int? UserSiteID { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "کلمات کلیدی (Keywords)")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات کوتاه (Description)")]
        public string MetaDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "بخش مخفی (محتوای اضافی)")]
        public string ExtraContent { get; set; }

        [Display(Name = "لیست نظرات")] // one-to-many
        public ICollection<Comment> Comments { set; get; } = new List<Comment>();

        [Display(Name = "لیست اخبار-دسته ها")] // one-to-many
        public ICollection<BlogJoinBlogCategory> BlogMultiCategories { set; get; } = new List<BlogJoinBlogCategory>();

        [NotMapped]
        [Display(Name = "لیست کاربران")]
        public ICollection<SelectListItem> UserSiteCategoryList { get; set; }

        [NotMapped]
        [Display(Name = "دسته بندی")]
        public int[] CategoryList { get; set; }
    }

    public partial class Blog
    {
        public static dynamic Select(int pageIndex, int pageSize, byte sw, out int total, int? categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case 1: // کاربران
                        if (categoryID == null)
                        {
                            var query = (from item in context.Blogs
                                         where item.Status == Status.Active
                                         orderby item.Rank descending, item.Date descending
                                         select new
                                         {
                                             item.ID,
                                             item.Title,
                                             item.Date,
                                             item.ShortBody,
                                             item.Url,
                                             item.FileUploadID,
                                             FileUploadRealName = item.FileUpload.RealName,
                                             item.UserSiteID,
                                             FullName = item.UserSite.FirstName + " " + item.UserSite.LastName,
                                             item.MetaKeywords
                                         }).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable()
                                         .Select(x => new
                                         {
                                             ID = x.ID,
                                             Title = x.Title,
                                             Title2 = x.Title.ReplaceAllChar(),
                                             Date = x.Date.ToPersianDate("d MMMM yyyy", false),
                                             ShortBody = x.ShortBody.Length > 185 ? (x.ShortBody.Substring(0, 185) + " ...") : x.ShortBody,
                                             Url = x.Url,
                                             FileUploadUrl = x.FileUploadID == null ? null : x.FileUploadRealName,
                                             Username = x.UserSiteID == null ? "مدیر" : x.FullName,
                                             MetaKeywords = x.MetaKeywords,
                                             CommentCount = Comment.Count(Status.Active, x.ID)
                                         }).ToList();
                            total = context.Blogs.Count(item => item.Status == Status.Active);
                            return query;
                        }
                        else
                        {
                            var query = (from item in context.BlogJoinBlogCategories
                                         where item.Blog.Status == Status.Active && item.BlogCategoryID == categoryID
                                         orderby item.Blog.Rank descending // item.Rank descending
                                         select new
                                         {
                                             ID = item.Blog.ID,
                                             Title = item.Blog.Title,
                                             Date = item.Blog.Date,
                                             ShortBody = item.Blog.ShortBody,
                                             Url = item.Blog.Url,
                                             FileUploadID = item.Blog.FileUploadID,
                                             FileUploadRealName = item.Blog.FileUpload.RealName,
                                             UserSiteID = item.Blog.UserSite,
                                             FullName = item.Blog.UserSite.FirstName + " " + item.Blog.UserSite.LastName,
                                             MetaKeywords = item.Blog.MetaKeywords
                                         }).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable()
                                         .Select(x => new
                                         {
                                             ID = x.ID,
                                             Title = x.Title,
                                             Title2 = x.Title.ReplaceAllChar(),
                                             Date = x.Date.ToPersianDate("d MMMM yyyy", false),
                                             ShortBody = x.ShortBody.Length > 185 ? (x.ShortBody.Substring(0, 185) + " ...") : x.ShortBody,
                                             Url = x.Url,
                                             FileUploadUrl = x.FileUploadID == null ? null : x.FileUploadRealName,
                                             Username = x.UserSiteID == null ? "مدیر" : x.FullName,
                                             MetaKeywords = x.MetaKeywords,
                                             CommentCount = Comment.Count(Status.Active, x.ID)
                                         }).ToList(); ;
                            total = context.BlogJoinBlogCategories.Count(item => item.Blog.Status == Status.Active && item.BlogCategoryID == categoryID);
                            return query;
                        }
                    case 2: // پنل مدیریت
                        if (categoryID == null)
                        {
                            var query = (from item in context.Blogs
                                         orderby item.Rank descending, item.Date descending
                                         select new
                                         {
                                             item.ID,
                                             item.Title,
                                             item.Date,
                                             item.FileUploadID,
                                             FileUploadRealName = item.FileUpload.RealName,
                                             item.Rank,
                                             item.Status,
                                             item.UserSiteID,
                                             UserSiteFirstName = item.UserSite.FirstName,
                                             UserSiteLastName = item.UserSite.LastName
                                         }).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable()
                                         .Select(x => new
                                         {
                                             ID = x.ID,
                                             Title = x.Title,
                                             Date = x.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                             FileUploadUrl = x.FileUploadID == null ? null : x.FileUploadRealName,
                                             Rank = x.Rank,
                                             Status = x.Status.DisplayName(),
                                             Username = x.UserSiteID == null ? "کاربر حذف شده" : (x.UserSiteFirstName + " " + x.UserSiteLastName),
                                             BlogCategory = BlogJoinBlogCategory.SelectString(x.ID),
                                             CommentCount = Comment.Count(x.ID)
                                         }).ToList();
                            total = context.Blogs.Count();
                            return query;
                        }
                        else
                        {
                            var query = (from item in context.BlogJoinBlogCategories
                                         where item.BlogCategoryID == categoryID
                                         orderby item.Blog.Rank descending // item.Rank descending
                                         select new
                                         {
                                             ID = item.Blog.ID,
                                             Title = item.Blog.Title,
                                             Date = item.Blog.Date,
                                             FileUploadID = item.Blog.FileUploadID,
                                             FileUploadRealName = item.Blog.FileUpload.RealName,
                                             Rank = item.Blog.Rank, // item.Rank
                                             Status = item.Blog.Status,
                                             UserSiteID = item.Blog.UserSiteID,
                                             UserSiteFirstName = item.Blog.UserSite.FirstName,
                                             UserSiteLastName = item.Blog.UserSite.LastName
                                         }).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable()
                                         .Select(x => new
                                         {
                                             ID = x.ID,
                                             Title = x.Title,
                                             Date = x.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                             FileUploadUrl = x.FileUploadID == null ? null : x.FileUploadRealName,
                                             Rank = x.Rank,
                                             Status = x.Status.DisplayName(),
                                             Username = x.UserSiteID == null ? "کاربر حذف شده" : (x.UserSiteFirstName + " " + x.UserSiteLastName),
                                             BlogCategory = BlogJoinBlogCategory.SelectString(x.ID),
                                             CommentCount = Comment.Count(x.ID)
                                         }).ToList(); ;
                            total = context.BlogJoinBlogCategories.Count(item => item.BlogCategoryID == categoryID);
                            return query;
                        }
                    default:
                        total = 0;
                        return null;
                }
            }
        }

        public static Blog Select(int id, byte sw)
        {
            switch (sw)
            {
                case 1: // سمت کاربران
                    {
                        ProjectModel context = new ProjectModel();
                        Blog obj = (from item in context.Blogs
                                    where item.ID == id && item.Status == Status.Active
                                    select item).SingleOrDefault();

                        try
                        {
                            obj.VisitCount++;
                            context.SaveChanges();
                        }
                        catch
                        {
                        }

                        return obj;
                    }
                case 2: // پنل مدیریت
                    {
                        using (ProjectModel context = new ProjectModel())
                        {
                            return (from item in context.Blogs.AsEnumerable()
                                    where item.ID == id
                                    select new Blog
                                    {
                                        Title = item.Title,
                                        ShortBody = item.ShortBody,
                                        Url = item.Url,
                                        FileUploadID = item.FileUploadID,
                                        ID = item.ID,
                                        FileUpload = item.FileUpload,
                                        Rank = item.Rank,
                                        Status = item.Status,
                                        UserSiteID = item.UserSiteID,
                                        UserSiteCategoryList = item.UserSiteCategoryList,
                                        Source = item.Source,
                                        SourceUrl = item.SourceUrl,
                                        CategoryList = item.CategoryList,
                                        Body = item.Body,
                                        Date = item.Date,
                                        UserSite = item.UserSite,
                                        VisitCount = item.VisitCount,
                                        MetaKeywords = item.MetaKeywords,
                                        MetaDescription = item.MetaDescription,
                                        ExtraContent = item.ExtraContent
                                    }).SingleOrDefault();
                        }
                    }
                default:
                    return null;
            }
        }

        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static List<Blog> Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active && item.ID != id
                        orderby Guid.NewGuid()
                        select new Blog
                        {
                            ID = item.ID,
                            Title = item.Title,
                            FileUploadID = item.FileUploadID,
                            FileUpload = item.FileUpload
                        }).Take(6).ToList();
            }
        }

        public static List<Blog> Select(string keyword)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active && (item.Title.Contains(keyword) || item.Body.Contains(keyword))
                        orderby item.Rank descending, item.Date descending
                        select new Blog
                        {
                            ID = item.ID,
                            Title = item.Title,
                            ShortBody = item.ShortBody,
                            Date = item.Date,
                            Url = item.Url
                        }).ToList();
            }
        }

        public static List<Blog> SelectTag(string keyword)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active && !string.IsNullOrWhiteSpace(item.MetaKeywords) && item.MetaKeywords.Contains(keyword)
                        orderby item.Rank descending, item.Date descending
                        select new Blog
                        {
                            ID = item.ID,
                            Title = item.Title,
                            ShortBody = item.ShortBody,
                            Date = item.Date
                        }).ToList();
            }
        }

        public static List<PostToXML> SelectRSS()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Rank descending
                        select new PostToXML
                        {
                            Description = item.ShortBody,
                            Link = item.Url != null ? item.Url : new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Details", "Blog", new { id = item.ID, text = item.Title.ReplaceAllChar() }, "http"),
                            PublishDate = item.Date,
                            Title = item.Title
                        }).ToList();
            }
        }

        public static List<PostToXML> SelectSiteMap()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active
                        select new PostToXML
                        {
                            Link = item.Url != null ? item.Url : new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Details", "Blog", new { id = item.ID, text = item.Title.ReplaceAllChar() }, "http")
                        }).ToList();
            }
        }

        public static string SelectTitle(int id)
        {
            try
            {
                using (ProjectModel context = new ProjectModel())
                {
                    return context.Blogs.Find(id).Title;
                }
            }
            catch
            {
                return "";
            }
        }

        public static List<PostJoinPostCategoryTopVM> SelectLast()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Blogs.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Rank descending
                        select new PostJoinPostCategoryTopVM
                        {
                            ID = item.ID,
                            Title = item.Title,
                            Url = item.Url,
                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                            VisitCount = item.VisitCount,
                            ShortBody = item.ShortBody
                        }).Take(4).ToList();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Blogs.RemoveRange(context.Blogs.Where(item => list.Contains(item.ID)));
                context.SaveChanges();
            }
        }

        public static void Insert(Blog obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                obj.Body = obj.Body.ToSafeHtml();
                obj.Rank = Select() + 1;
                context.Blogs.Add(obj);
                context.SaveChanges();
            }

            BlogJoinBlogCategory.Insert(obj.ID, obj.CategoryList);
        }

        public static void Update(int blogID, string type, int? categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                if (categoryID == null)
                {
                    switch (type)
                    {
                        case "plus":
                            context.Blogs.Find(blogID).Rank++;
                            break;
                        case "minus":
                            context.Blogs.Find(blogID).Rank--;
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "plus":
                            context.Blogs.Find(blogID).Rank++;
                            break;
                        case "minus":
                            context.Blogs.Find(blogID).Rank--;
                            break;
                            //case "plus":
                            //    context.BlogJoinBlogCategories.Single(item => item.BlogID == blogID && item.BlogCategoryID == categoryID).Rank++;
                            //    break;
                            //case "minus":
                            //    context.BlogJoinBlogCategories.Single(item => item.BlogID == blogID && item.BlogCategoryID == categoryID).Rank--;
                            //    break;
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Update(Blog obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                obj.Body = obj.Body.ToSafeHtml();
                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(x => x.Date).IsModified = false;
                entry.Property(x => x.VisitCount).IsModified = false;
                context.SaveChanges();
                BlogJoinBlogCategory.Delete(obj.ID);
                BlogJoinBlogCategory.Insert(obj.ID, obj.CategoryList);
            }
        }
    }
}