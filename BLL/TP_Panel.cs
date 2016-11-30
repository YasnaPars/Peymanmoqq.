using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BLL
{
    // جدول پنل های صفحه اول
    [Table("TP_Panel")]
    public partial class Panel
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ درج")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [DataType(DataType.Url, ErrorMessage = "یک آدرس اینترنتی را وارد کنید")]
        [Display(Name = "لینک مقصد")]
        public string Url { get; set; }

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

    public partial class Panel
    {
        public static Panel Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var temp = (from item in context.Panels
                            where item.ID == id
                            select new
                            {
                                item.Title,
                                item.Description,
                                item.Url,
                                item.FileUploadID,
                                item.FileUpload,
                                item.Rank,
                                item.Status
                            }).FirstOrDefault();

                return new Panel()
                {
                    Title = temp.Title,
                    Description = temp.Description,
                    Url = temp.Url,
                    FileUploadID = temp.FileUploadID,
                    FileUpload = temp.FileUpload,
                    Rank = temp.Rank,
                    Status = temp.Status
                };
            }
        }

        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Panels
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = (from item in context.Panels
                             orderby item.Rank descending, item.Date descending
                             select new
                             {
                                 item.ID,
                                 item.FileUploadID,
                                 FileUploadRealName = item.FileUpload.RealName,
                                 item.Title,
                                 item.Description,
                                 item.Url,
                                 item.Date,
                                 item.Status,
                                 item.Rank
                             }).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable()
                             .Select(x => new
                             {
                                 ID = x.ID,
                                 FileUploadUrl = x.FileUploadID == null ? null : x.FileUploadRealName,
                                 Title = x.Title,
                                 Description = x.Description,
                                 Url = x.Url,
                                 Date = x.Date.ToPersianDate("d MMMM yyyy - HH:mm", false),
                                 Status = x.Status.DisplayName(),
                                 Rank = x.Rank
                             }).ToList();

                total = context.Panels.Count();
                return query;
            }
        }

        public static List<Panel> SelectList()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.Panels
                        where item.Status == Status.Active
                        orderby item.Rank descending, item.Date descending
                        select new
                        {
                            item.Url,
                            item.Title,
                            item.Description,
                            item.FileUploadID,
                            item.FileUpload
                        }).Take(3).AsEnumerable()
                        .Select(x => new Panel
                        {
                            Url = x.Url,
                            Title = x.Title,
                            Description = x.Description,
                            FileUploadID = x.FileUploadID,
                            FileUpload = x.FileUpload
                        }).ToList();
            }
        }

        public static void Insert(Panel obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.Panels.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Update(Panel obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                obj.Url = obj.Url.Trim();
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
                        context.Database.ExecuteSqlCommand(@"update [TP_Panel] set Rank = Rank + 1 where ID = {0}", id);
                        break;
                    case "minus":
                        context.Database.ExecuteSqlCommand(@"update [TP_Panel] set Rank = Rank - 1 where ID = {0}", id);
                        break;
                }

                context.SaveChanges();
            }
        }

        public static void Delete(params int[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                foreach (var item in list)
                {
                    var entry = context.Entry(new Panel { ID = item });
                    entry.State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }
    }
}