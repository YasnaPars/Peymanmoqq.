using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace BLL
{
    // جدول انواع فایل های آپلود شده
    [Table("TP_FileUploadType")]
    public partial class FileUploadType
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public short ID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "نوع فایل")]
        public string Title { get; set; }

        [Display(Name = "لیست فایل ها")] // one-to-many
        public ICollection<FileUpload> FileUploads { set; get; } = new List<FileUpload>();
    }

    public partial class FileUploadType
    {
        public static IList<SelectListItem> Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return context.FileUploadTypes.OrderBy(item => item.Title).Select(item => new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Title
                }).ToList();
            }
        }

        public static short Insert(string title)
        {
            using (ProjectModel context = new ProjectModel())
            {
                FileUploadType obj = context.FileUploadTypes.FirstOrDefault(item => item.Title == title);

                if (obj == null)
                {
                    obj = new FileUploadType
                    {
                        Title = title
                    };
                    context.FileUploadTypes.Add(obj);
                    context.SaveChanges();
                }

                return obj.ID;
            }
        }
    }
}