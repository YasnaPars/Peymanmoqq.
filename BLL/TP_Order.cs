using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    // جدول ارسال سفارش
    [Table("TP_Order")]
    public partial class Order
    {
        [Key]
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره همراه")]
        public string MobileNumber { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره ثابت")]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [Display(Name = "تاریخ سفارش")]
        public DateTime OrderDate { set; get; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "دسته محصول")]
        public int ProductCategoryID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "محصول")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "مقدار")]
        public string Value { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "رنگ")]
        public string Color { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات سفارش")]
        public string Description { get; set; }

        [Display(Name = "فایل ارسالی")]
        public string FileName { get; set; }

        [Display(Name = "تاریخ درج")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Range(0, 1, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت درخواست")]
        public RequestStatus RequestStatus { get; set; } = RequestStatus.OnProgress;

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; } = Select() + 1;
    }

    // مدل اضافه کردن یک سفارش
    public class OrderInsertVM : Profile
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره همراه")]
        public string MobileNumber { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره ثابت")]
        public string Phone { get; set; }

        [UIHint("PersianDatePicker")]
        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [Display(Name = "تاریخ سفارش")]
        public DateTime OrderDate { set; get; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "مقدار")]
        public string Value { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "رنگ")]
        public string Color { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات سفارش")]
        public string Description { get; set; }

        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "دسته بندی")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "لیست دسته محصولات")]
        public IList<SelectListItem> ProductCategoryList { get; set; }

        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "عنوان محصول")]
        public int ProductID { get; set; }

        [Display(Name = "لیست محصولات")]
        public IList<SelectListItem> ProductList { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "فیلد مخفی نگهدارنده آی دی محصول")]
        public int HiddenSubItemID { get; set; }

        [ValidateWord]
        [Display(Name = "ارسال فایل")]
        public HttpPostedFileBase PostedFile { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(3, ErrorMessage = "حداکثر 3 کاراکتر مجاز می باشد")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, short.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }
    }

    // مدل نمایش یک درخواست
    public class OrderDetailsVM
    {
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Display(Name = "شماره همراه")]
        public string MobileNumber { get; set; }

        [Display(Name = "شماره ثابت")]
        public string Phone { get; set; }

        [Display(Name = "تاریخ سفارش")]
        public string OrderDate { set; get; }

        [Display(Name = "عنوان دسته ی محصول")]
        public string ProductCategory { get; set; }

        [Display(Name = "عنوان محصول")]
        public string Product { get; set; }

        [Display(Name = "مقدار")]
        public string Value { get; set; }

        [Display(Name = "رنگ")]
        public string Color { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات سفارش")]
        public string Description { get; set; }

        [Display(Name = "فایل ارسالی")]
        public string FileName { get; set; }

        [Display(Name = "تاریخ درج")]
        public string Date { get; set; }

        [Display(Name = "بررسی شد؟")]
        public string RequestStatus { get; set; }

        [Display(Name = "اولویت")]
        public int Rank { get; set; }
    }

    public partial class Order
    {
        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Orders
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.Orders.AsEnumerable()
                            orderby item.Rank descending, item.Date descending
                            select new
                            {
                                ID = item.ID,
                                FileName = item.FileName,
                                FullName = item.FullName,
                                MobileNumber = item.MobileNumber,
                                Phone = item.Phone,
                                Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                Rank = item.Rank,
                                RequestStatus = item.RequestStatus
                            };
                total = query.Count();
                return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static OrderDetailsVM Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Orders.AsEnumerable()
                        where item.ID == id
                        select new OrderDetailsVM
                        {
                            ID = item.ID,
                            FullName = item.FullName,
                            Email = item.Email,
                            MobileNumber = item.MobileNumber,
                            Phone = item.Phone,
                            OrderDate = item.OrderDate.ToPersianDate("d MMMM yyyy", false),
                            ProductCategory = item.ProductCategory.Title,
                            Product = item.Product.Title,
                            Value = item.Value,
                            Color = item.Color,
                            Description = item.Description,
                            FileName = item.FileName,
                            Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                            RequestStatus = item.RequestStatus == RequestStatus.Send ? "بله" : "خیر",
                            Rank = item.Rank
                        }).SingleOrDefault();
            }
        }

        public static int SelectNew()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Orders
                        where item.RequestStatus == RequestStatus.OnProgress
                        select item).Count();
            }
        }

        public static void Insert(Order obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Orders.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Orders.Remove(context.Orders.Find(id));
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
                        context.Orders.Find(id).Rank++;
                        break;
                    case "minus":
                        context.Orders.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }

        public static void Update(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                Order query = context.Orders.Find(id);
                query.RequestStatus = query.RequestStatus == RequestStatus.Send ? RequestStatus.OnProgress : RequestStatus.Send;
                context.SaveChanges();
            }
        }
    }
}