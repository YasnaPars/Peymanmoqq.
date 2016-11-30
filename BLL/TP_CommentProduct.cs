using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BLL
{
    // جدول نظرات محصولات
    [Table("TP_CommentProduct")]
    public partial class CommentProduct
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Display(Name = "تاریخ درج")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "تاریخ پاسخ")]
        public DateTime AnswerDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(1000, ErrorMessage = "حداکثر 1000 کاراکتر مجاز می باشد")]
        [Display(Name = "متن پیام")]
        public string Body { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "متن پاسخ")]
        public string Answer { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; } = Status.OnProgress;

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره محصول")]
        public int ProductID { get; set; }
    }

    // مدل اضافه کردن یک نظر سمت کاربران
    public class CommentProductInsertVM
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(1000, ErrorMessage = "حداکثر 1000 کاراکتر مجاز می باشد")]
        [Display(Name = "متن پیام")]
        public string Body { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره محصول")]
        public int PostID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(3, ErrorMessage = "حداکثر 3 کاراکتر مجاز می باشد")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, byte.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }
    }

    public partial class CommentProduct
    {
        public static int Count(int id)
        {
            string temp = HttpContext.Current.Request.RequestContext.HttpContext.CacheRead<string>("CommentProductCount_" + id);

            if (string.IsNullOrWhiteSpace(temp))
            {
                using (ProjectModel context = new ProjectModel())
                {
                    temp = context.CommentProducts.Count(item => item.ProductID == id).ToString();
                }

                HttpContext.Current.Request.RequestContext.HttpContext.CacheInsert("CommentProductCount_" + id, temp, 30);
            }

            return Convert.ToInt32(temp);
        }

        public static int Count(Status status, int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.CommentProducts.Count(item => item.Status == status && item.ProductID == id);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, Status status, out int total, int? id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.CommentProducts.AsEnumerable()
                            where item.Status == status && (id.HasValue ? item.ProductID == id : true)
                            orderby item.Date descending, item.ID descending
                            select new
                            {
                                ID = item.ID,
                                FullName = item.FullName,
                                Body = item.Body,
                                Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                Email = item.Email,
                                Status = item.Status.DisplayName(),
                                Answer = item.Answer,
                                AnswerDate = item.AnswerDate.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                ProductID = item.Product.ID,
                                ProductTitle = item.Product.Title.Length > 100 ? (item.Product.Title.Substring(0, 100) + " ...") : item.Product.Title,
                            };
                total = query.Count();
                return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static CommentProduct Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.CommentProducts.AsEnumerable()
                        where item.ID == id
                        select new CommentProduct
                        {
                            FullName = item.FullName,
                            ID = item.ID,
                            ProductID = item.ProductID,
                            Email = item.Email,
                            Body = item.Body,
                            Answer = item.Answer,
                            Status = item.Status
                        }).SingleOrDefault();
            }
        }

        public static List<CommentProduct> SelectList(int productID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.CommentProducts.AsEnumerable()
                        where item.Status == Status.Active && item.ProductID == productID && item.Product.Status == Status.Active
                        orderby item.Date descending, item.ID descending
                        select new CommentProduct
                        {
                            FullName = item.FullName,
                            Body = item.Body,
                            Date = item.Date,
                            Answer = item.Answer,
                            AnswerDate = item.AnswerDate
                        }).ToList();
            }
        }

        public static int SelectNew()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.CommentProducts
                        where item.Status == Status.OnProgress
                        select item).Count();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                CommentProduct obj = context.CommentProducts.Find(id);
                context.CommentProducts.Remove(obj);
                context.SaveChanges();
                HttpContext.Current.Request.RequestContext.HttpContext.InvalidateCache("CommentProductCount_" + obj.ProductID);
            }
        }

        public static void Update(int id, Status type)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.CommentProducts.Find(id).Status = type;
                context.SaveChanges();
            }
        }

        public static void Update(CommentProduct obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(x => x.Date).IsModified = false;
                context.SaveChanges();
            }
        }

        public static void Insert(CommentProduct obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.CommentProducts.Add(obj);
                context.SaveChanges();
                HttpContext.Current.Request.RequestContext.HttpContext.InvalidateCache("CommentProductCount_" + obj.ProductID);
            }
        }
    }
}