using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BLL
{
    // جدول ایمیل ها
    [Table("TP_Email")]
    public partial class Email
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public short ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "ایمیل")]
        public string Username { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "آدرس هاست")]
        public string Host { get; set; }

        [Display(Name = "شماره پورت")]
        public short Port { get; set; }

        [Display(Name = "وضعیت SSL")]
        public bool Ssl { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }

    public partial class Email
    {
        public static List<Email> Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Emails.AsEnumerable()
                        select new Email
                        {
                            ID = item.ID,
                            Username = item.Username,
                            Password = item.Password,
                            Host = item.Host,
                            Port = item.Port,
                            Ssl = item.Ssl,
                            Description = item.Description
                        }).ToList();
            }
        }

        public static string[] SelectArray(params string[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Emails.AsEnumerable()
                        where list.Any(val => item.Username.Contains(val))
                        select item.Username).ToArray();
            }
        }

        public static void Update(Email obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Emails.Attach(obj);
                var entry = context.Entry(obj);
                entry.Property(x => x.Username).IsModified = true;
                entry.Property(x => x.Password).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}