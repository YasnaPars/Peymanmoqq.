using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    // جدول فایل های آپلود شده
    [Table("TP_FileUpload")]
    public partial class FileUpload
    {
        [Key]
        [Display(Name = "شماره فایل")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان فایل")]
        public string Title { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "مسیر واقعی")]
        public string RealName { get; set; }

        [ForeignKey("FileUploadTypeID")]
        public virtual FileUploadType FileUploadType { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, short.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "نوع فایل")]
        public short FileUploadTypeID { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        [Display(Name = "حجم فایل (KB)")]
        public float Size { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدود مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [ForeignKey("FileUploadCategoryID")]
        public virtual FileUploadCategory FileUploadCategory { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "نام دسته")]
        public int? FileUploadCategoryID { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "لیست فایل های اخبار")] // many-to-one
        public ICollection<Blog> Blogs { set; get; } = new List<Blog>();

        [Display(Name = "لیست فایل های اسلایدرها")] // many-to-one
        public ICollection<Slider> Sliders { set; get; } = new List<Slider>();

        [Display(Name = "لیست فایل های گواهینامه ها")] // many-to-one
        public ICollection<Certificate> Certificates { set; get; } = new List<Certificate>();

        [Display(Name = "لیست فایل های پنل ها")] // many-to-one
        public ICollection<Panel> Panels { set; get; } = new List<Panel>();

        [Display(Name = "لیست فایل های محصولات")] // many-to-one
        public ICollection<Product> Products { set; get; } = new List<Product>();

        [Display(Name = "لیست فایل های دسته بندی محصولات")] // many-to-one
        public ICollection<ProductCategory> ProductCategories { set; get; } = new List<ProductCategory>();
    }

    // مدل اضافه کردن یک فایل
    public class FileUploadInsertVM
    {
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان فایل")]
        public string Title { get; set; }

        [ValidateFile]
        [Required(ErrorMessage = "لطفا یک فایل انتخاب نمایید")]
        [Display(Name = "انتخاب فایل")]
        public HttpPostedFileBase file { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "انتخاب دسته")]
        public int FileUploadCategoryID { get; set; }

        [Display(Name = "لیست دسته ها")]
        public IList<SelectListItem> CategoryList { get; set; }
    }

    // مدل ویرایش یک فایل
    public class FileUploadUpdateVM
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "شماره فایل")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان فایل")]
        public string Title { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدود مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "انتخاب دسته")]
        public int FileUploadCategoryID { get; set; }

        [Display(Name = "لیست دسته ها")]
        public IList<SelectListItem> CategoryList { get; set; }
    }

    public partial class FileUpload
    {
        public static FileUpload Select(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.FileUploads.AsEnumerable()
                        where item.ID == id
                        select new FileUpload
                        {
                            Title = item.Title,
                            ID = item.ID,
                            Rank = item.Rank,
                            FileUploadCategoryID = item.FileUploadCategoryID
                        }).SingleOrDefault();
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total, int? categoryID, int? typeID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.FileUploads.AsEnumerable()
                            where (categoryID != null ? item.FileUploadCategoryID == categoryID : true) && (typeID != null ? item.FileUploadTypeID == typeID : true)
                            select new
                            {
                                ID = item.ID,
                                RealName = item.RealName,
                                Title = item.Title,
                                FullUrl = string.Format("http://www.{0}/Data/Admin/{1}", ClsMain.SiteUrl, item.RealName),
                                Type = item.FileUploadType.Title,
                                Size = string.Format("{0:n}", item.Size),
                                CategoryTitle = item.FileUploadCategory.Title,
                                Date = item.Date.ToPersianDate("dddd d MMMM yyyy - HH:mm", false),
                                Rank = item.Rank,
                            };
                total = query.Count();

                if (categoryID == null)
                {
                    return query.OrderByDescending(item => item.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return query.OrderByDescending(item => item.Rank).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
        }

        public static int SelectRank(int categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.FileUploads
                        where item.FileUploadCategoryID == categoryID
                        select item.Rank).MaxOrDefault(0);
            }
        }

        public static dynamic SelectImage(int pageIndex, int pageSize, out int total, int? categoryID)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.FileUploads.AsEnumerable()
                            where (categoryID != null ? item.FileUploadCategoryID == categoryID : true) && (item.FileUploadType.Title == "image/png" || item.FileUploadType.Title == "image/gif" || item.FileUploadType.Title == "image/jpeg" || item.FileUploadType.Title == "image/pjpeg" || item.FileUploadType.Title == "image/bmp")
                            select new
                            {
                                ID = item.ID,
                                RealName = item.RealName,
                                Title = item.Title,
                                Type = item.FileUploadType.Title,
                                Size = string.Format("{0:n}", item.Size),
                                Date = item.Date,
                                Rank = item.Rank
                            };
                total = query.Count();

                if (categoryID == null)
                {
                    return query.OrderByDescending(item => item.Date).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return query.OrderByDescending(item => item.Rank).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
        }

        public static void Insert(FileUpload obj)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.FileUploads.Add(obj);
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.FileUploads.Remove(context.FileUploads.Find(id));
                context.SaveChanges();
            }
        }

        public static void Update(FileUploadUpdateVM model)
        {
            using (ProjectModel context = new ProjectModel())
            {
                FileUpload obj = context.FileUploads.Find(model.ID);
                obj.Title = model.Title;
                obj.Rank = model.Rank;
                obj.FileUploadCategoryID = model.FileUploadCategoryID;
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
                        context.FileUploads.Find(id).Rank++;
                        break;
                    case "minus":
                        context.FileUploads.Find(id).Rank--;
                        break;
                }

                context.SaveChanges();
            }
        }
    }
}