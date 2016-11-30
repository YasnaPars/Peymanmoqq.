using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace BLL
{
    // جدول اخبار-دسته بندی
    [Table("TP_BlogJoinBlogCategory")]
    public partial class BlogJoinBlogCategory
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [ForeignKey("BlogCategoryID")]
        public virtual BlogCategory BlogCategory { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره دسته")]
        public int BlogCategoryID { get; set; }

        [ForeignKey("BlogID")]
        public virtual Blog Blog { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره خبر")]
        public int BlogID { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }
    }

    // مدل نمایش آخرین اخبار
    public class PostJoinPostCategoryTopVM
    {
        [Display(Name = "شماره خبر")]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "لینک مقصد")]
        public string Url { get; set; }

        [Display(Name = "آدرس فایل")]
        public string FileUploadUrl { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int VisitCount { get; set; }

        [Display(Name = "چکیده")]
        public string ShortBody { get; set; }
    }

    public partial class BlogJoinBlogCategory
    {
        public static int Select(int blogCategoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.BlogJoinBlogCategories
                        where item.BlogCategoryID == blogCategoryID
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static List<PostJoinPostCategoryTopVM> SelectLast()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.BlogJoinBlogCategories.AsEnumerable()
                        where item.Blog.Status == Status.Active && item.BlogCategory.Title == "اخبار ویژه"
                        orderby item.Rank descending
                        select new PostJoinPostCategoryTopVM
                        {
                            ID = item.Blog.ID,
                            Title = item.Blog.Title,
                            Url = item.Blog.Url
                        }).Take(6).ToList();
            }
        }

        public static string SelectString(int blogID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return string.Join(", ", context.BlogJoinBlogCategories.Where(item => item.BlogID == blogID).Select(item => item.BlogCategory.Title).ToArray());
            }
        }

        public static int[] SelectList(int blogID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.BlogJoinBlogCategories.AsEnumerable()
                        where item.BlogID == blogID
                        select item.BlogCategoryID).ToArray();
            }
        }

        public static void Insert(int blogID, int[] categoryList)
        {
            using (ProjectModel context = new ProjectModel())
            {
                if (categoryList == null)
                {
                    BlogJoinBlogCategory bmc = new BlogJoinBlogCategory() { BlogCategoryID = BlogCategory.Select(), BlogID = blogID, Rank = Select(BlogCategory.Select()) + 1 };
                    context.BlogJoinBlogCategories.Add(bmc);
                }
                else
                {
                    foreach (var item in categoryList)
                    {
                        BlogJoinBlogCategory bmc = new BlogJoinBlogCategory() { BlogCategoryID = item, BlogID = blogID, Rank = Select(item) + 1 };
                        context.BlogJoinBlogCategories.Add(bmc);
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Delete(int blogID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.BlogJoinBlogCategories.RemoveRange(context.BlogJoinBlogCategories.Where(item => item.BlogID == blogID));
                context.SaveChanges();
            }
        }
    }
}