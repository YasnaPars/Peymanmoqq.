using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    // جدول دسته بندی اخبار
    [Table("TP_BlogCategory")]
    public partial class BlogCategory
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان دسته")]
        public string Title { get; set; }

        [Display(Name = "لیست اخبار-دسته ها")] // one-to-many
        public ICollection<BlogJoinBlogCategory> BlogMultiCategories { set; get; } = new List<BlogJoinBlogCategory>();
    }

    public partial class BlogCategory
    {
        public static int Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.BlogCategories.FirstOrDefault().ID;
            }
        }

        public static IList<SelectListItem> SelectList(params int[] listID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.BlogCategories.OrderBy(item => item.Title).Select(item => new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Title,
                    Selected = listID.Any(val => item.ID == val)
                }).ToList();
            }
        }

        public static string[] SelectString()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.BlogCategories.AsEnumerable()
                        orderby item.Title
                        select "'blog?category=" + item.ID + "' : " + item.Title).ToArray();
            }
        }

        public static List<PostToXML> SelectSiteMap()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.BlogCategories.AsEnumerable()
                        select new PostToXML
                        {
                            Link = new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Index", "Blog", new { category = item.ID }, "http")
                        }).ToList();
            }
        }
    }
}