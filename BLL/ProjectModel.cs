using System.Data.Entity;

namespace BLL
{
    public class ProjectModel : DbContext
    {
        public ProjectModel() : base("name=ProjectModel")
        {
            //خصوصیات فیلدهای جداول
            //[Key]  تعریف کلید برای جدول
            //[Table("tblProject", Schema = "guest")]  تغییر نام جدول بانک اطلاعاتی و همچنین اگر Schema کاربر رشته اتصالی به بانک اطلاعاتی dbo نیست، باید آن‌را در اینجا صریحا ذکر کنید
            //[ScaffoldColumn(false)]  خاصیتی کلا از رابط کاربری حذف می شود
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]  غیرفعال کردن حالت افزایشی آی دی و همچنین تعریف فیلد محاسباتی
            //[Display(Name = "کلید اصلی")]  Tozih: تعیین برچسب برای یک فیلد
            //[Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
            //[Compare("Password", ErrorMessage = "تکرار رمز عبور با رمز عبور مطابقت ندارد")]
            //[StringLength(50, MinimumLength = 6, ErrorMessage = "حداقل 6 و حداکثر 50 کاراکتر مجاز می باشد")]
            //[MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر مجاز می باشد"), MinLength(6, ErrorMessage = "حداقل 6 کاراکتر مجاز می باشد")]  Tozih: بهتره بجای MaxLength از StringLength استفاده شود تا اعتبارسنجی سمت کاربران نیز فعال شود
            //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]  Tozihat: اعتبارسنجی برای عدد
            //[Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]  Tozihat: اعتبارسنجی برای عدد
            //[NotMapped]  فیلدی سمت برنامه که در بانک اطلاعاتی قرار نخواهد گرفت
            //[HiddenInput]  به شکل یک فیلد مخفی در صفحه ظاهر می شود در صورتیکه از EditFor استفاده شود
            //[HiddenInput(DisplayValue = false)]  مشابه بالا می باشد با این تفاوت که در بالا مقدارش را هم نمایش می دهد ولی اینجا نه
            //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "فرمت {0} نادرست است")]  Tozih: اعتبارسنجی ایمیل
            //[Column(Order = 4)]  از صفر شروع می‌شود، می توان ترتیب قرارگیری فیلدها در حین تشکیل یک جدول را مشخص کرد
            //[Column(TypeName = "date")]
            //[Column(TypeName = "varchar(MAX)")]
            //[Column("MyTableKey")]  تغییر نام ستون یک فیلد
            //[DataType(DataType.Date)]  مشخص کرده‌ایم که نوع ورودی فقط قرار است Date باشد و نیازی به قسمت Time آن نداریم. در حالت EditorFor بیشتر کاربرد دارد و همچنین DisplayFor
            //[DataType(DataType.Url, ErrorMessage = "یک آدرس وب وارد کنید")]
            //[DisplayFormat(NullDisplayText = "-")]  اگر مقدار خاصیت خالی بود، تبدیل به - می شود
            //[DisplayFormat(NullDisplayText = "-", ConvertEmptyStringToNull = false)]  مشابه بالا می باشد با این تفاوت در حالتیکه مقدار فیلد خالی باشد و نه null، مقدار - نمایش داده نمی شود
            //[DisplayFormat(DataFormatString = "{0:n}")]  نمایش عدد با دو رقم اعشار
            //[DisplayFormat(DataFormatString = "/{0:n}", ApplyFormatInEditMode = true)]  مشابه بالا به این تفاوت در حالت ویرایش نیز نشان داده می شود
            //[AllowHtml]  مجاز به دریافت تگ های html خواهد بود
            //var allErrors = ModelState.Values.SelectMany(v => v.Errors);  بدست آوردن تمام خطاها
        }

        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DynamicPart> DynamicParts { get; set; }
        public virtual DbSet<DynamicPage> DynamicPages { get; set; }
        public virtual DbSet<FileUploadCategory> FileUploadCategories { get; set; }
        public virtual DbSet<FileUploadType> FileUploadTypes { get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<BlogJoinBlogCategory> BlogJoinBlogCategories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentProduct> CommentProducts { get; set; }
        public virtual DbSet<DynamicMenu> DynamicMenus { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Panel> Panels { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductJoinProductCategory> ProductJoinProductCategories { get; set; }
        public virtual DbSet<ProductRating> ProductRatings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        // به این روش Fluent API می گویند
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DynamicMenuConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}