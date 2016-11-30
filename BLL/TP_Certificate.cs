using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BLL
{
    // جدول گواهینامه ها
    [Table("TP_Certificate")]
    public partial class Certificate
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان اصلی")]
        public string Title { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(200, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان تصویر")]
        public string Alt { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime Date { get; set; } = DateTime.Now;

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
    }

    public partial class Certificate
    {
        public static Certificate Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Certificates.AsEnumerable()
                        where item.ID == id
                        select new Certificate
                        {
                            Title = item.Title,
                            Alt = item.Alt,
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
                return (from item in context.Certificates
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
                            var query = from item in context.Certificates.AsEnumerable()
                                        where item.Status == Status.Active
                                        orderby item.Rank descending, item.Date descending
                                        select new
                                        {
                                            Title = item.Title,
                                            Alt = item.Alt,
                                            FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName
                                        };
                            total = query.Count();
                            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        }
                    case 2: // پنل مدیریت
                        {
                            var query = from item in context.Certificates.AsEnumerable()
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

        public static List<Certificate> SelectList()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Certificates.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Rank descending, item.Date descending
                        select new Certificate
                        {
                            Title = item.Title,
                            Alt = item.Alt,
                            FileUploadID = item.FileUploadID,
                            FileUpload = item.FileUpload
                        }).ToList();
            }
        }

        public static void Insert(Certificate obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Certificates.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Update(Certificate obj)
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
                        context.Certificates.Find(id).Rank++;
                        break;
                    case "minus":
                        context.Certificates.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Certificates.RemoveRange(context.Certificates.Where(item => list.Contains(item.ID)));
                context.SaveChanges();
            }
        }
    }
}