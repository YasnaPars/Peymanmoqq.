using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    // جدول منوهای داینامیک
    [Table("TP_DynamicMenu")]
    public partial class DynamicMenu
    {
        [Key]
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "آدرس صفحه")]
        public string Location { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان منو")]
        public string Title { get; set; }

        [Display(Name = "تاریخ درج")]
        public DateTime Date { get; set; } = DateTime.Now;

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [Display(Name = "اولویت")]
        public int Rank { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "آیکون")]
        public string Icon { get; set; }

        [ForeignKey("ParentID")]
        public virtual DynamicMenu Parent { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "منوی مادر")]
        public int? ParentID { get; set; }

        [Display(Name = "لیست فرزندان")] // one-to-many
        public IList<DynamicMenu> Children { set; get; } = new List<DynamicMenu>();
    }

    // مدل اضافه کردن یک رکورد سمت مدیر
    public class DynamicMenuInsertVM
    {
        [Display(Name = "شماره رکورد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز می باشد")]
        [Display(Name = "آدرس صفحه")]
        public string Location { get; set; }

        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است")]
        [StringLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        [Display(Name = "عنوان منو")]
        public string Title { get; set; }

        [Range(0, 2, ErrorMessage = "گزینه انتخاب شده صحیح نمی باشد")]
        [Display(Name = "وضعیت نمایش")]
        public Status Status { get; set; }

        [StringLength(30, ErrorMessage = "حداکثر 30 کاراکتر مجاز می باشد")]
        [Display(Name = "آیکون")]
        public string Icon { get; set; }

        [ForeignKey("ParentID")]
        public virtual DynamicMenu Parent { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "منوی مادر")]
        public int? ParentID { get; set; }

        [Display(Name = "لیست فرزندان")] // one-to-many
        public IList<DynamicMenu> Children { set; get; } = new List<DynamicMenu>();

        [Display(Name = "صفحات آماده")]
        public string ReadyPages { set; get; }

        [Required(ErrorMessage = "انتخاب فیلد {0} الزامی است")]
        [RegularExpression("[0-9]*", ErrorMessage = "عدد وارد شده صحیح نمی باشد")]
        [Range(0, int.MaxValue, ErrorMessage = "عدد وارد شده در محدوده مجاز نمی باشد")]
        [Display(Name = "بعد از")]
        public int SubMenuID { get; set; }

        [Display(Name = "زیر منوها")]
        public IList<SelectListItem> SubMenu { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "فیلد مخفی نگهدارنده آی دی زیر منو")]
        public int HiddenSubMenuID { get; set; }
    }

    public class DynamicMenuConfig : EntityTypeConfiguration<DynamicMenu>
    {
        public DynamicMenuConfig()
        {
            HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentID)
                .WillCascadeOnDelete(false);
        }
    }

    public partial class DynamicMenu
    {
        public static List<DynamicMenu> Select(byte sw)
        {
            using (ProjectModel context = new ProjectModel())
            {
                switch (sw)
                {
                    case 1: // کاربران
                        List<DynamicMenu> temp = HttpContext.Current.Request.RequestContext.HttpContext.CacheRead<List<DynamicMenu>>("DynamicMenu");

                        if (temp != null && temp.Any())
                        {
                            return temp;
                        }
                        else
                        {
                            List<DynamicMenu> list = (from item in context.DynamicMenus.Include(x => x.Parent)
                                                      where item.Status == Status.Active
                                                      orderby item.Rank
                                                      select item).ToList().Where(item => item.Parent == null).ToList();

                            HttpContext.Current.Request.RequestContext.HttpContext.CacheInsert("DynamicMenu", list, 20);
                            return list;
                        }
                    case 2: // پنل مدیریت
                        return (from item in context.DynamicMenus.Include(x => x.Parent)
                                orderby item.Rank
                                select item).ToList().Where(item => item.Parent == null).ToList();
                    default:
                        return null;
                }
            }
        }

        public static DynamicMenu SelectSingle(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicMenus.Include(x => x.Parent)
                        where item.ID == id // && (item.ParentID == item.Parent.ID || item.Parent == null)
                        select item).SingleOrDefault();
            }
        }

        public static IList<SelectListItem> SelectList(int id, int? parentId)
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicMenus
                        where item.ParentID == parentId
                        orderby item.Rank
                        select new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.Title,
                            Selected = (item.ID == id)
                        }).ToList();
            }
        }

        public static List<PostToXML> SelectSiteMap()
        {
            using (ProjectModel context = new ProjectModel())
            {
                return (from item in context.DynamicMenus.AsEnumerable()
                        where item.Status == Status.Active && !item.Location.StartsWith("http")
                        select new PostToXML
                        {
                            Link = ClsMain.SiteUrl + item.Location
                        }).ToList();
            }
        }

        public static void Insert(int? parentID, int id, DynamicMenu model)
        {
            using (ProjectModel context = new ProjectModel())
            {
                DynamicMenu temp = context.DynamicMenus.SingleOrDefault(item => item.ID == id);
                var query = (from item in context.DynamicMenus
                             where item.ParentID == parentID
                             select item);

                if (temp != null)
                {
                    query = query.Where(item => item.Rank > temp.Rank);
                    model.Rank = temp.Rank + 1;
                }
                else
                {
                    model.Rank = 1;
                }

                query.ToList().ForEach(item => item.Rank++);
                context.DynamicMenus.Add(model);

                if (!model.Location.StartsWith("http"))
                {
                    if (context.DynamicPages.SingleOrDefault(item => item.Location == model.Location) == null)
                    {
                        context.DynamicPages.Add(new DynamicPage { Title = "صفحه جدید", Location = model.Location });
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Update(DynamicMenuInsertVM model)
        {
            using (ProjectModel context = new ProjectModel())
            {
                DynamicMenu obj = Mapper.Map<DynamicMenu>(model);
                DynamicMenu temp = context.DynamicMenus.AsNoTracking().SingleOrDefault(item => item.ID == model.SubMenuID);
                var query = (from item in context.DynamicMenus
                             where item.ParentID == model.ParentID
                             select item);

                if (temp != null)
                {
                    query = query.Where(item => item.Rank > temp.Rank);
                    obj.Rank = temp.Rank + 1;
                }
                else
                {
                    obj.Rank = 1;
                }

                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(x => x.Date).IsModified = false;
                query.ToList().ForEach(item => item.Rank++);

                if (!obj.Location.StartsWith("http"))
                {
                    if (context.DynamicPages.SingleOrDefault(item => item.Location == obj.Location) == null)
                    {
                        context.DynamicPages.Add(new DynamicPage { Title = "صفحه جدید", Location = obj.Location });
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ProjectModel context = new ProjectModel())
            {
                context.DynamicMenus.Remove(context.DynamicMenus.Find(id));
                context.SaveChanges();
            }
        }
    }
}