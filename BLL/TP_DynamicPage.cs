using HtmlCleaner;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول صفحات داینامیک
    [Table("TP_DynamicPage")]
    public partial class DynamicPage
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "آدرس")]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "محتویات")]
        public string Body { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "کلمات کلیدی (Keywords)")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر مجاز می باشد")]
        [Display(Name = "توضیحات کوتاه (Description)")]
        public string MetaDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "بخش مخفی (محتوای اضافی)")]
        public string ExtraContent { get; set; }
    }

    // مدل انتخاب صفحه
    public class DynamicPageVM
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "انتخاب صفحه")]
        public int? PageID { get; set; }

        [Display(Name = "لیست صفحات")]
        public IEnumerable<SelectListItem> List { get; set; }

        [Display(Name = "جزئیات صفحه")]
        public DynamicPage DynamicPage { get; set; }

        [Display(Name = "دکمه ذخیره یا حذف صفحه")]
        public string BtnDynamicPage { get; set; }
    }

    public partial class DynamicPage
    {
        public static DynamicPage Select(string location)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var temp = (from item in context.DynamicPages
                            where item.Location == location
                            select new
                            {
                                Title = item.Title,
                                Body = item.Body,
                                MetaKeywords = item.MetaKeywords,
                                MetaDescription = item.MetaDescription,
                                ExtraContent = item.ExtraContent
                            }).FirstOrDefault();

                if (temp != null)
                {
                    return new DynamicPage()
                    {
                        Title = temp.Title,
                        Body = temp.Body,
                        MetaKeywords = temp.MetaKeywords,
                        MetaDescription = temp.MetaDescription,
                        ExtraContent = temp.ExtraContent
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public static DynamicPage Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicPages.AsEnumerable()
                        where item.ID == id
                        select new DynamicPage
                        {
                            Title = item.Title,
                            Body = item.Body,
                            MetaKeywords = item.MetaKeywords,
                            MetaDescription = item.MetaDescription,
                            ExtraContent = item.ExtraContent
                        }).SingleOrDefault();
            }
        }

        public static IList<SelectListItem> SelectList(int? id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.DynamicPages.Select(item => new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Title + " (" + item.Location + ")",
                    Selected = (item.ID == id.Value)
                }).ToList();
            }
        }

        public static string[] SelectString()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicPages.AsEnumerable()
                        where item.Location.StartsWith("/page/")
                        orderby item.Location
                        select "'" + item.Location + "' : " + item.Title).ToArray();
            }
        }

        public static void Update(DynamicPageVM obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                DynamicPage dp = context.DynamicPages.Find(obj.PageID);
                dp.Title = obj.DynamicPage.Title;
                dp.Body = obj.DynamicPage.Body.ToSafeHtml();
                dp.MetaKeywords = obj.DynamicPage.MetaKeywords;
                dp.MetaDescription = obj.DynamicPage.MetaDescription;
                dp.ExtraContent = obj.DynamicPage.ExtraContent;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.DynamicPages.Remove(context.DynamicPages.Find(id));
                context.SaveChanges();
            }
        }
    }
}