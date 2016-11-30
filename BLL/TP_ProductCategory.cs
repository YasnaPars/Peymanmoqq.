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
    // جدول دسته بندی محصولات
    [Table("TP_ProductCategory")]
    public partial class ProductCategory
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان دسته")]
        public string Title { get; set; }

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

        [Display(Name = "تاریخ ایجاد")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; }

        [Display(Name = "لیست محصولات-دسته ها")] // one-to-many
        public ICollection<ProductJoinProductCategory> ProductJoinProductCategories { set; get; } = new List<ProductJoinProductCategory>();
    }

    public partial class ProductCategory
    {
        public static ProductCategory Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductCategories.AsEnumerable()
                        where item.ID == id
                        select new ProductCategory
                        {
                            Title = item.Title,
                            FileUploadID = item.FileUploadID,
                            FileUpload = item.FileUpload,
                            Rank = item.Rank,
                            Status = item.Status
                        }).SingleOrDefault();
            }
        }

        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductCategories
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, byte sw, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case 1: // کاربران
                        {
                            var query = from item in context.ProductCategories.AsEnumerable()
                                        where item.Status == Status.Active
                                        orderby item.Rank descending, item.Date descending
                                        select new
                                        {
                                            ID = item.ID,
                                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                                            Title = item.Title,
                                            Title2 = item.Title.ReplaceAllChar()
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                    case 2: // پنل مدیریت
                        {
                            var query = from item in context.ProductCategories.AsEnumerable()
                                        orderby item.Rank descending, item.Date descending
                                        select new
                                        {
                                            ID = item.ID,
                                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                                            Title = item.Title,
                                            Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                            Status = item.Status.DisplayName(),
                                            Rank = item.Rank
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

        public static int SelectFirst()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.ProductCategories.FirstOrDefault().ID;
            }
        }

        public static IList<SelectListItem> SelectList(byte sw, params int[] listID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case 1: // سمت کاربران
                        return (from item in context.ProductCategories
                                where item.Status == Status.Active
                                orderby item.Rank descending, item.Date descending
                                select new SelectListItem
                                {
                                    Value = item.ID.ToString(),
                                    Text = item.Title,
                                    Selected = listID.Any(val => item.ID == val)
                                }).ToList();
                    case 2: // سمت مدیریت
                        return (from item in context.ProductCategories
                                orderby item.Rank descending, item.Date descending
                                select new SelectListItem
                                {
                                    Value = item.ID.ToString(),
                                    Text = item.Title,
                                    Selected = listID.Any(val => item.ID == val)
                                }).ToList();
                    default:
                        return null;
                }
            }
        }

        public static List<PostToXML> SelectSiteMap()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductCategories.AsEnumerable()
                        where item.Status == Status.Active
                        select new PostToXML
                        {
                            Link = new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Index", "Product", new { id = item.ID, text = item.Title.ReplaceAllChar() }, "http")
                        }).ToList();
            }
        }

        public static string[] SelectString()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductCategories.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Title
                        select "'product?category=" + item.ID + "' : " + item.Title).ToArray();
            }
        }

        public static void Update(ProductCategory obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(x => x.Date).IsModified = false;
                context.SaveChanges();
            }
        }

        public static void Update(int id, string type)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (type)
                {
                    case "plus":
                        context.ProductCategories.Find(id).Rank++;
                        break;
                    case "minus":
                        context.ProductCategories.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }

        public static void Insert(ProductCategory obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.ProductCategories.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.ProductCategories.RemoveRange(context.ProductCategories.Where(item => list.Contains(item.ID) && item.ID != 1));
                context.SaveChanges();
            }
        }
    }
}