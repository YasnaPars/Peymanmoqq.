using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول محصولات-دسته بندی
    [Table("TP_ProductJoinProductCategory")]
    public partial class ProductJoinProductCategory
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, short.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره دسته")]
        public int ProductCategoryID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره محصول")]
        public int ProductID { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }
    }

    public partial class ProductJoinProductCategory
    {
        public static int[] Select(int productID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductJoinProductCategories.AsEnumerable()
                        where item.ProductID == productID
                        select item.ProductCategoryID).ToArray();
            }
        }

        public static IList<SelectListItem> Select(int pId, params int[] listID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.ProductJoinProductCategories.Where(item => item.ProductCategoryID == pId).Select(item => new SelectListItem
                {
                    Value = item.Product.ID.ToString(),
                    Text = item.Product.Title,
                    Selected = listID.Any(val => item.Product.ID == val)
                }).ToList();
            }
        }

        public static int SelectRank(int productCategoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductJoinProductCategories
                        where item.ProductCategoryID == productCategoryID
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static string SelectString(int productID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return string.Join(", ", context.ProductJoinProductCategories.Where(item => item.ProductID == productID).Select(item => item.ProductCategory.Title).ToArray());
            }
        }

        public static List<PostJoinPostCategoryTopVM> SelectLast()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductJoinProductCategories.AsEnumerable()
                        where item.Product.Status == Status.Active && item.ProductCategory.Title == "محصولات ویژه"
                        orderby item.Rank descending
                        select new PostJoinPostCategoryTopVM
                        {
                            ID = item.Product.ID,
                            Title = item.Product.Title,
                            FileUploadUrl = item.Product.FileUploadID == null ? null : item.Product.FileUpload.RealName,
                            ShortBody = item.Product.ShortBody
                        }).Take(7).ToList();
            }
        }

        public static void Insert(int productID, int[] categoryList)
        {
            using (ProjectModel context = new ProjectModel())
            {
                if (categoryList == null)
                {
                    ProductJoinProductCategory ppc = new ProductJoinProductCategory() { ProductCategoryID = ProductCategory.SelectFirst(), ProductID = productID, Rank = SelectRank(ProductCategory.SelectFirst()) + 1 };
                    context.ProductJoinProductCategories.Add(ppc);
                }
                else
                {
                    foreach (var item in categoryList)
                    {
                        ProductJoinProductCategory ppc = new ProductJoinProductCategory() { ProductCategoryID = item, ProductID = productID, Rank = SelectRank(item) + 1 };
                        context.ProductJoinProductCategories.Add(ppc);
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Delete(int productID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.ProductJoinProductCategories.RemoveRange(context.ProductJoinProductCategories.Where(item => item.ProductID == productID));
                context.SaveChanges();
            }
        }
    }
}