using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BLL
{
    // جدول تماس با ما
    [Table("TP_Contact")]
    public partial class Contact
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "تلفن همراه")]
        public string Phone { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره تلگرام")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(150, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(1000, ErrorMessage = "حداکثر 1000 کاراکتر مجاز می باشد")]
        [Display(Name = "متن پیام")]
        public string Body { get; set; }

        [Display(Name = "تاریخ ارسال پیام")]
        public DateTime Date { get; set; }

        [Display(Name = "تاریخ حذف پیام")]
        public DateTime? DeleteDate { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت خوانده شدن")]
        public Status ReadStatus { get; set; } = Status.DeActive;

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت ستاره دار بودن")]
        public Status StarStatus { get; set; } = Status.DeActive;

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "پیام حذف شده یا خیر")]
        public Status DeleteStatus { get; set; } = Status.DeActive;
    }

    // مدل اضافه کردن یک رکورد سمت کاربران
    public class ContactInsertVM
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

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "تلفن همراه")]
        public string Phone { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "شماره تلگرام")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(150, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(1000, ErrorMessage = "حداکثر 1000 کاراکتر مجاز می باشد")]
        [Display(Name = "متن پیام")]
        public string Body { get; set; }

        [Display(Name = "تاریخ ارسال پیام")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(3, ErrorMessage = "حداکثر 3 کاراکتر مجاز می باشد")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, byte.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }
    }

    public partial class Contact
    {
        public static Tuple<int, int, int> Count()
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = (from item in context.Contacts.AsEnumerable()
                             group item by 1 into temp
                             select new
                             {
                                 inboxCount = temp.Count(c => c.DeleteStatus == Status.DeActive && c.ReadStatus == Status.DeActive),
                                 starCount = temp.Count(c => c.StarStatus == Status.Active && c.DeleteStatus == Status.DeActive && c.ReadStatus == Status.DeActive),
                                 deleteCount = temp.Count(c => c.DeleteStatus == Status.Active && c.ReadStatus == Status.DeActive)
                             }).FirstOrDefault();

                if (query != null)
                {
                    return Tuple.Create(query.inboxCount, query.starCount, query.deleteCount);
                }
                else
                {
                    return Tuple.Create(0, 0, 0);
                }
            }
        }

        public static int Count(string sw)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case "inbox":
                        return context.Contacts.Count(item => item.DeleteStatus == Status.DeActive);
                    case "star":
                        return context.Contacts.Count(item => item.StarStatus == Status.Active && item.DeleteStatus == Status.DeActive);
                    case "trash":
                        return context.Contacts.Count(item => item.DeleteStatus == Status.Active);
                    default:
                        return 0;
                }
            }
        }

        public static List<Contact> Select(string sw)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case "inbox":
                        return (from item in context.Contacts.AsEnumerable()
                                where item.DeleteStatus == Status.DeActive
                                orderby item.Date descending
                                select new Contact
                                {
                                    ID = item.ID,
                                    Date = item.Date,
                                    FullName = item.FullName,
                                    Subject = item.Subject.Length > 70 ? (item.Subject.Substring(0, 70) + " ...") : item.Subject,
                                    Email = (!string.IsNullOrWhiteSpace(item.Email) && item.Email.Length > 30) ? (item.Email.Substring(0, 30) + " ...") : item.Email,
                                    Phone = item.Phone,
                                    Body = item.Body.Length > 70 ? item.Body.Substring(0, 70) : item.Body,
                                    ReadStatus = item.ReadStatus,
                                    StarStatus = item.StarStatus,
                                    DeleteStatus = item.DeleteStatus
                                }).ToList();
                    case "star":
                        return (from item in context.Contacts.AsEnumerable()
                                where item.StarStatus == Status.Active && item.DeleteStatus == Status.DeActive
                                orderby item.Date descending
                                select new Contact
                                {
                                    ID = item.ID,
                                    Date = item.Date,
                                    FullName = item.FullName,
                                    Subject = item.Subject.Length > 70 ? (item.Subject.Substring(0, 70) + " ...") : item.Subject,
                                    Email = (!string.IsNullOrWhiteSpace(item.Email) && item.Email.Length > 30) ? (item.Email.Substring(0, 30) + " ...") : item.Email,
                                    Phone = item.Phone,
                                    Body = item.Body.Length > 70 ? item.Body.Substring(0, 70) : item.Body,
                                    ReadStatus = item.ReadStatus,
                                    StarStatus = item.StarStatus,
                                    DeleteStatus = item.DeleteStatus
                                }).ToList();
                    case "trash":
                        return (from item in context.Contacts.AsEnumerable()
                                where item.DeleteStatus == Status.Active
                                orderby item.DeleteDate descending
                                select new Contact
                                {
                                    ID = item.ID,
                                    Date = item.Date,
                                    FullName = item.FullName,
                                    Subject = item.Subject.Length > 70 ? (item.Subject.Substring(0, 70) + " ...") : item.Subject,
                                    Email = (!string.IsNullOrWhiteSpace(item.Email) && item.Email.Length > 30) ? (item.Email.Substring(0, 30) + " ...") : item.Email,
                                    Phone = item.Phone,
                                    Body = item.Body.Length > 70 ? item.Body.Substring(0, 70) : item.Body,
                                    ReadStatus = item.ReadStatus,
                                    StarStatus = item.StarStatus,
                                    DeleteStatus = item.DeleteStatus
                                }).ToList();
                    default:
                        return null;
                }
            }
        }

        public static Contact Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Contacts.AsEnumerable()
                        where item.ID == id
                        select new Contact
                        {
                            FullName = item.FullName,
                            Subject = item.Subject,
                            Date = item.Date,
                            DeleteStatus = item.DeleteStatus,
                            ID = item.ID,
                            StarStatus = item.StarStatus,
                            Email = item.Email,
                            Phone = item.Phone,
                            Mobile = item.Mobile,
                            Body = item.Body
                        }).SingleOrDefault();
            }
        }

        public static int SelectNew()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Contacts
                        where item.ReadStatus == Status.DeActive
                        select item).Count();
            }
        }

        public static void UpdateStar(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                Contact query = context.Contacts.Find(id);
                query.StarStatus = query.StarStatus == Status.Active ? Status.DeActive : Status.Active;
                context.SaveChanges();
            }
        }

        public static void Update(int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Contacts.Where(item => list.Contains(item.ID)).ToList().ForEach(item => item.DeleteStatus = Status.DeActive);
                context.SaveChanges();
            }
        }

        public static void Update(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Contacts.Find(id).ReadStatus = Status.Active;
                context.SaveChanges();
            }
        }

        public static void Delete(int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                foreach (int item in list)
                {
                    Contact temp = context.Contacts.Find(item);

                    if (temp.DeleteStatus == Status.Active)
                    {
                        context.Contacts.Remove(temp);
                    }
                    else
                    {
                        temp.DeleteStatus = Status.Active;
                        temp.DeleteDate = DateTime.Now;
                    }
                }

                context.SaveChanges();
            }
        }

        public static bool Insert(Contact obj)
        {
            try
            {
                using (ProjectModel context = new ProjectModel())
                {
                    context.Contacts.Add(obj);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}