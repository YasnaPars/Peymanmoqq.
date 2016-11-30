using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول دسته بندی فایل های آپلود شده
    [Table("TP_FileUploadCategory")]
    public partial class FileUploadCategory
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان دسته")]
        public string Title { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "لیست فایل ها")] // one-to-many
        public ICollection<FileUpload> FileUploads { set; get; } = new List<FileUpload>();
    }

    public partial class FileUploadCategory
    {
        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.FileUploadCategories
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.FileUploadCategories.AsEnumerable()
                            orderby item.Rank descending, item.Date descending
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Rank = item.Rank,
                                Date = item.Date.ToPersianDate("dddd d MMMM yyyy - HH:mm", false)
                            };
                total = query.Count();
                return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static FileUploadCategory Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.FileUploadCategories.AsEnumerable()
                        where item.ID == id
                        select new FileUploadCategory
                        {
                            Title = item.Title,
                            ID = item.ID,
                            Rank = item.Rank
                        }).SingleOrDefault();
            }
        }

        public static IList<SelectListItem> SelectList(int? id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.FileUploadCategories.OrderByDescending(item => item.Rank).ThenByDescending(item => item.Date).Select(item => new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Title,
                    Selected = (item.ID == id.Value)
                }).ToList();
            }
        }

        public static void Insert(FileUploadCategory obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.FileUploadCategories.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.FileUploadCategories.Remove(context.FileUploadCategories.Single(item => item.ID == id && item.ID != 1));
                context.SaveChanges();
            }
        }

        public static void Update(FileUploadCategory obj)
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
                        context.FileUploadCategories.Find(id).Rank++;
                        break;
                    case "minus":
                        context.FileUploadCategories.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }
    }
}