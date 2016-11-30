using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول امتیاز محصولات
    [Table("TP_ProductRating")]
    public partial class ProductRating
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "شماره محصول")]
        public int ProductID { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; } = Status.Active;

        [Display(Name = "تاریخ درج")]
        public DateTime Date { get; set; } = DateTime.Now;

        [RegularExpression("([1-5])", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, 5, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "امتیاز")]
        public byte Rating { get; set; }
    }

    // مدل نمایش امتیازات سمت کاربران
    public class ProductRatingVM
    {
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Display(Name = "مجموع امتیازات")]
        public int SumRating { get; set; }

        [Display(Name = "تعداد رای دهندگان")]
        public int TotalRaters { get; set; }

        [Display(Name = "می تواند رای دهد یا خیر")]
        public bool Readonly { get; set; }

        [Display(Name = "امتیاز جاری")]
        public byte CurrentRating { get; set; }
    }

    public partial class ProductRating
    {
        public static ProductRatingVM Select(int itemID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductRatings.AsEnumerable()
                        where item.ProductID == itemID && item.Status == Status.Active
                        group item by item.ProductID into grp
                        select new ProductRatingVM
                        {
                            ID = grp.Key,
                            SumRating = (from row in grp select (int)row.Rating).Sum(),
                            TotalRaters = (from row in grp select row.ID).Count()
                        }).FirstOrDefault();
            }
        }

        public static double SelectAvg(int itemID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.ProductRatings.AsEnumerable()
                        where item.ProductID == itemID && item.Status == Status.Active
                        group item by item.ProductID into grp
                        select (double)(from row in grp select (int)row.Rating).Sum() / (from row in grp select row.ID).Count()).FirstOrDefault();
            }
        }

        public static void Insert(ProductRating obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.ProductRatings.Add(obj);
                context.SaveChanges();
            }
        }
    }
}