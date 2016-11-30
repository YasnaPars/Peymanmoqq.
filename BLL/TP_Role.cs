using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL
{
    // جدول نقش ها
    [Table("TP_Role")]
    public partial class Role
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public short ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان فارسی")]
        public string FaTitle { get; set; }

        [Display(Name = "لیست لاگین ها")] // one-to-many
        public IList<Login> Logins { set; get; } = new List<Login>();
    }

    public partial class Role
    {
    }
}