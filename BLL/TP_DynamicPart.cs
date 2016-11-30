using HtmlCleaner;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول بخش های داینامیک
    [Table("TP_DynamicPart")]
    public partial class DynamicPart
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(2000, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "محتویات")]
        public string Body { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "textarea یا textbox")]
        public bool IsTextarea { get; set; }

        [Display(Name = "چپ به راست یا راست به چپ")]
        public bool IsLTR { get; set; }
    }

    public partial class DynamicPart
    {
        public static List<DynamicPart> Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.DynamicParts.Where(item => item.Title != "یادداشت").ToList();
            }
        }

        public static string[] Select(params string[] list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicParts
                        where list.Any(val => item.Title.Contains(val))
                        select item.Body).ToArray();
            }
        }

        public static string Select(string title)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.DynamicParts.Single(item => item.Title == title).Body;
            }
        }

        public static void Update(DynamicPart obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.DynamicParts.Single(item => item.Title == obj.Title).Body = obj.Body.ToSafeHtml();
                context.SaveChanges();
            }
        }

        public static void Update(List<DynamicPart> list)
        {
            using (ProjectModel context = new ProjectModel())
            {
                foreach (var item in list)
                {
                    item.Body = item.Body;
                    context.DynamicParts.Attach(item);
                    var entry = context.Entry(item);
                    entry.Property(x => x.Body).IsModified = true;
                    entry.Property(x => x.Description).IsModified = true;
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}