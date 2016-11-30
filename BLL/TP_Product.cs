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
    // جدول محصولات
    [Table("TP_Product")]
    public partial class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "کد محصول")]
        public string Code { get; set; }

        [DataType(DataType.Url, ErrorMessage = "یک آدرس اینترنتی را وارد کنید")]
        [Display(Name = "آدرس دکمه")]
        public string CatalogUrl { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "متن روی دکمه")]
        public string CatalogTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "رنگ ها")]
        public string Color { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(1000, ErrorMessage = "حداکثر 1000 کاراکتر مجاز می باشد")]
        [Display(Name = "چکیده")]
        public string ShortBody { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن اصلی")]
        public string Body { get; set; }

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

        [Timestamp]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "کنترل مسایل همزمانی تغییر رکورد")]
        public byte[] RowVersion { set; get; }

        [Display(Name = "لیست محصولات-دسته ها")] // one-to-many
        public ICollection<ProductJoinProductCategory> ProductJoinProductCategories { set; get; } = new List<ProductJoinProductCategory>();

        [Display(Name = "لیست محصولات-امتیازها")] // one-to-many
        public ICollection<ProductRating> ProductRatings { set; get; } = new List<ProductRating>();

        [Display(Name = "لیست نظرات")] // one-to-many
        public ICollection<CommentProduct> CommentProducts { set; get; } = new List<CommentProduct>();

        [NotMapped]
        [Display(Name = "دسته بندی")]
        public int[] CategoryList { get; set; }

        [NotMapped]
        [Display(Name = "لیست کاربران")]
        public IList<SelectListItem> UserSiteCategoryList { get; set; }
    }

    public partial class Product
    {
        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Products
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static Product Select(int id, byte sw)
        {
            switch (sw)
            {
                case 1: // سمت کاربران
                    {
                        ProjectModel context = new ProjectModel();
                        Product obj = (from item in context.Products
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
                            return (from item in context.Products.AsEnumerable()
                                    where item.ID == id
                                    select new Product
                                    {
                                        Title = item.Title,
                                        Code = item.Code,
                                        Color = item.Color,
                                        CatalogUrl = item.CatalogUrl,
                                        CatalogTitle = item.CatalogTitle,
                                        ShortBody = item.ShortBody,
                                        FileUploadID = item.FileUploadID,
                                        FileUpload = item.FileUpload,
                                        ID = item.ID,
                                        Rank = item.Rank,
                                        Status = item.Status,
                                        UserSiteID = item.UserSiteID,
                                        UserSite = item.UserSite,
                                        UserSiteCategoryList = item.UserSiteCategoryList,
                                        CategoryList = item.CategoryList,
                                        Body = item.Body,
                                        Date = item.Date,
                                        VisitCount = item.VisitCount,
                                        MetaKeywords = item.MetaKeywords,
                                        MetaDescription = item.MetaDescription,
                                        ExtraContent = item.ExtraContent,
                                        RowVersion = item.RowVersion
                                    }).SingleOrDefault();
                        }
                    }
                default:
                    return null;
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, byte sw, out int total, int? categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case 1: // کاربران
                        if (categoryID == null)
                        {
                            var query = from item in context.Products.AsEnumerable()
                                        where item.Status == Status.Active
                                        orderby item.Rank descending, item.Date descending
                                        select new
                                        {
                                            ID = item.ID,
                                            Title = item.Title,
                                            Title2 = item.Title.ReplaceAllChar(),
                                            Code = item.Code,
                                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                                            MetaKeywords = item.MetaKeywords
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                        else
                        {
                            var query = from item in context.ProductJoinProductCategories.AsEnumerable()
                                        where item.ProductCategoryID == categoryID && item.ProductCategory.Status == Status.Active && item.Product.Status == Status.Active
                                        orderby item.Product.Rank descending // item.Rank descending
                                        select new
                                        {
                                            ID = item.Product.ID,
                                            Title = item.Product.Title,
                                            Title2 = item.Product.Title.ReplaceAllChar(),
                                            Code = item.Product.Code,
                                            FileUploadUrl = item.Product.FileUploadID == null ? null : item.Product.FileUpload.RealName,
                                            MetaKeywords = item.Product.MetaKeywords
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                    case 2: // پنل مدیریت
                        if (categoryID == null)
                        {
                            var query = from item in context.Products.AsEnumerable()
                                        orderby item.Rank descending, item.Date descending
                                        select new
                                        {
                                            ID = item.ID,
                                            Title = item.Title,
                                            Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                                            Rank = item.Rank,
                                            Status = item.Status.DisplayName(),
                                            ProductCategory = ProductJoinProductCategory.SelectString(item.ID),
                                            Username = item.UserSiteID == null ? "کاربر حذف شده" : item.UserSite.FullName,
                                            CommentCount = CommentProduct.Count(item.ID),
                                            Rating = string.Format("{0:0.00}", ProductRating.SelectAvg(item.ID))
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                        else
                        {
                            var query = from item in context.ProductJoinProductCategories.AsEnumerable()
                                        where item.ProductCategoryID == categoryID
                                        orderby item.Product.Rank descending // item.Rank descending
                                        select new
                                        {
                                            ID = item.Product.ID,
                                            Title = item.Product.Title,
                                            Date = item.Product.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                            FileUploadUrl = item.Product.FileUploadID == null ? null : item.Product.FileUpload.RealName,
                                            Rank = item.Product.Rank, // item.Rank
                                            Status = item.Product.Status.DisplayName(),
                                            ProductCategory = ProductJoinProductCategory.SelectString(item.Product.ID),
                                            Username = item.Product.UserSiteID == null ? "کاربر حذف شده" : item.Product.UserSite.FullName,
                                            CommentCount = CommentProduct.Count(item.Product.ID),
                                            Rating = string.Format("{0:0.00}", ProductRating.SelectAvg(item.Product.ID))
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                    default:
                        total = 0;
                        return null;
                }
            }
        }

        public static List<Product> Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Products.AsEnumerable()
                        where item.Status == Status.Active && item.ID != id
                        orderby Guid.NewGuid()
                        select new Product
                        {
                            ID = item.ID,
                            Title = item.Title,
                            Code = item.Code,
                            FileUploadID = item.FileUploadID,
                            FileUpload = item.FileUpload
                        }).Take(4).ToList();
            }
        }

        public static List<Product> Select(string keyword)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Products.AsEnumerable()
                        where item.Status == Status.Active && (item.Title.Contains(keyword) || item.Body.Contains(keyword))
                        orderby item.Rank descending, item.Date descending
                        select new Product
                        {
                            ID = item.ID,
                            Title = item.Title,
                            ShortBody = item.ShortBody,
                            Date = item.Date
                        }).ToList();
            }
        }

        public static List<PostToXML> SelectSiteMap()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Products.AsEnumerable()
                        where item.Status == Status.Active
                        select new PostToXML
                        {
                            Link = new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Details", "Product", new { id = item.ID, text = item.Title.ReplaceAllChar() }, "http")
                        }).ToList();
            }
        }

        public static string SelectTitle(int id)
        {
            try
            {
                using (ProjectModel context = new ProjectModel())
                {
                    return context.Products.Find(id).Title;
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
                return (from item in context.Products.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Rank descending
                        select new PostJoinPostCategoryTopVM
                        {
                            ID = item.ID,
                            Title = item.Title,
                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName
                        }).Take(9).ToList();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Products.RemoveRange(context.Products.Where(item => list.Contains(item.ID)));
                context.SaveChanges();
            }
        }

        public static void Update(Product obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                obj.Body = obj.Body.ToSafeHtml();
                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(x => x.Date).IsModified = false;
                entry.Property(x => x.VisitCount).IsModified = false;
                context.SaveChanges();
                ProductJoinProductCategory.Delete(obj.ID);
                ProductJoinProductCategory.Insert(obj.ID, obj.CategoryList);
            }
        }

        public static void Update(int productID, string type, int? categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                if (categoryID == null)
                {
                    switch (type)
                    {
                        case "plus":
                            context.Products.Find(productID).Rank++;
                            break;
                        case "minus":
                            context.Products.Find(productID).Rank--;
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "plus":
                            context.Products.Find(productID).Rank++;
                            break;
                        case "minus":
                            context.Products.Find(productID).Rank--;
                            break;
                        //case "plus":
                        //    context.ProductJoinProductCategories.Single(item => item.ProductID == productID && item.ProductCategoryID == categoryID).Rank++;
                        //    break;
                        //case "minus":
                        //    context.ProductJoinProductCategories.Single(item => item.ProductID == productID && item.ProductCategoryID == categoryID).Rank--;
                        //    break;
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Insert(Product obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                obj.Body = obj.Body.ToSafeHtml();
                obj.Rank = Select() + 1;
                context.Products.Add(obj);
                context.SaveChanges();
            }

            ProductJoinProductCategory.Insert(obj.ID, obj.CategoryList);
        }
    }
}