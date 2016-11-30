using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول کاربران سایت
    [Table("TP_UserSite")]
    public partial class UserSite : Login
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Range(0, 1, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "تلفن")]
        public string Tell { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "کد فعال سازی")]
        public string ActiveCode { get; set; }

        [Display(Name = "لیست اخبار")] // many-to-one
        public IList<Blog> Blogs { set; get; } = new List<Blog>();

        [Display(Name = "لیست محصولات")] // many-to-one
        public IList<Product> Products { set; get; } = new List<Product>();

        [NotMapped]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    // مدل بازیابی رمز عبور
    public class UserSiteRecoverPasswordVM
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(3, ErrorMessage = "حداکثر 3 کاراکتر مجاز می باشد")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, short.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }
    }

    public partial class UserSite
    {
        public static UserSite Select(string username, string password)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Logins.OfType<UserSite>().AsEnumerable()
                        where item.Username == username && item.Password == password
                        select new UserSite
                        {
                            Username = item.Username,
                            Status = item.Status,
                            Role = item.Role,
                            FirstName = item.FirstName,
                            LastName = item.LastName
                        }).Single();
            }
        }

        public static IList<SelectListItem> SelectList(params int[] listID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Logins.OfType<UserSite>().AsEnumerable()
                        where item.Username != "support@ariafanavari.ir"
                        orderby item.FirstName, item.LastName
                        select new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.FullName,
                            Selected = listID.Any(val => item.ID == val)
                        }).ToList();
            }
        }

        public static string SelectName(string username)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.Logins.OfType<UserSite>().FirstOrDefault(item => item.Username == username).FullName;
            }
        }

        public static void Update(string username)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Logins.OfType<UserSite>().Single(item => item.Username == username).LastLoginDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static void Update(string username, string oldPass, string newPass)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Logins.OfType<UserSite>().Single(item => item.Username == username && item.Password == oldPass).Password = newPass;
                context.SaveChanges();
            }
        }

        public static Status Update(string email, string key)
        {
            using (ProjectModel context = new ProjectModel())
            {
                UserSite obj = context.Logins.OfType<UserSite>().Single(item => item.Email == email);
                obj.ActiveCode = key;
                context.SaveChanges();
                return obj.Status;
            }
        }

        public static UserSite UpdatePassword(string key, string password)
        {
            using (ProjectModel context = new ProjectModel())
            {
                UserSite obj = context.Logins.OfType<UserSite>().Single(item => item.ActiveCode == key);
                obj.Password = password;
                obj.ActiveCode = "";
                context.SaveChanges();
                return obj;
            }
        }
    }
}