using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BLL
{
    // جدول اسلایدر صفحه اول
    [Table("TP_Slider")]
    public partial class Slider
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان اصلی")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان فرعی")]
        public string SubTitle { get; set; }

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

    public partial class Slider
    {
        public static Slider Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Sliders.AsEnumerable()
                        where item.ID == id
                        select new Slider
                        {
                            Title = item.Title,
                            SubTitle = item.SubTitle,
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
                return (from item in context.Sliders
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.Sliders.AsEnumerable()
                            orderby item.Rank descending, item.Date descending
                            select new
                            {
                                ID = item.ID,
                                FileUploadUrl = item.FileUploadID == null ? null : item.FileUpload.RealName,
                                Title = item.Title,
                                SubTitle = item.SubTitle,
                                Date = item.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                Status = item.Status.DisplayName(),
                                Rank = item.Rank
                            };
                total = query.Count();
                return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static List<Slider> SelectList()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Sliders.AsEnumerable()
                        where item.Status == Status.Active
                        orderby item.Rank descending, item.Date descending
                        select new Slider
                        {
                            FileUploadID = item.FileUploadID,
                            FileUpload = item.FileUpload,
                            Title = item.Title,
                            SubTitle = item.SubTitle,
                        }).ToList();
            }
        }

        public static void Insert(Slider obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Sliders.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Update(Slider obj)
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
                        context.Sliders.Find(id).Rank++;
                        break;
                    case "minus":
                        context.Sliders.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Sliders.RemoveRange(context.Sliders.Where(item => list.Contains(item.ID)));
                context.SaveChanges();
            }
        }
    }
}