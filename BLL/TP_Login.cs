using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL
{
    // جدول لاگین
    [Table("TP_Login")]
    public partial class Login
    {
        [Key]
        [Display(Name = "شناسه کاربر")]
        public int ID { get; set; }

        [Index]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "تاریخ آخرین ورود به سایت")]
        public DateTime LastLoginDate { get; set; } = DateTime.Now;

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت کاربر")]
        public Status Status { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, short.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "نقش کاربر")]
        public short RoleID { get; set; }
    }

    // مدل لاگین مدیر
    public class LoginAdminVM
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberStatus { get; set; }

        [Display(Name = "لینک بازگشت")]
        public string ReturnUrl { get; set; }
    }

    // مدل تغییر رمز
    public class LoginChangePasswordVM
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور قبلی")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور جدید")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "تکرار رمز عبور جدید با رمز عبور جدید مطابقت ندارد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور جدید")]
        public string NewPasswordConfirm { get; set; }
    }

    public partial class Login
    {
    }
}