using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BLL
{
    // جدول آمار بازدید
    [Table("TP_Statistic")]
    public partial class Statistic
    {
        [Key]
        [Display(Name = "کلید اصلی")]
        public int ID { get; set; }

        [Display(Name = "کروم")]
        public int Chrome { get; set; }

        [Display(Name = "فایرفاکس")]
        public int Firefox { get; set; }

        [Display(Name = "موزیلا")]
        public int Mozilla { get; set; }

        [Display(Name = "اپرا")]
        public int Opera { get; set; }

        [Display(Name = "سافاری")]
        public int Safari { get; set; }

        [Display(Name = "اینترنت اکسپلورر")]
        public int IE { get; set; }

        [Display(Name = "بلک بری")]
        public int BlackBerry { get; set; }

        [Display(Name = "سایر")]
        public int Unknown { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        [Display(Name = "تعداد کل")]
        public int Total
        {
            get { return Chrome + Firefox + Mozilla + Opera + Safari + IE + BlackBerry + Unknown; }
        }
    }

    // مدل خلاصه آمار بازدید
    public class SummaryStatisticVM
    {
        [Display(Name = "امروز")]
        public int Today { get; set; }

        [Display(Name = "دیروز")]
        public int Yesterday { get; set; }

        [Display(Name = "این ماه")]
        public int Month { get; set; }

        [Display(Name = "ماه گذشته")]
        public int PrevMonth { get; set; }

        [Display(Name = "امسال")]
        public int Year { get; set; }

        [Display(Name = "سال گذشته")]
        public int PrevYear { get; set; }

        [Display(Name = "تعداد کل")]
        public int Total { get; set; }

        [Display(Name = "کاربران آنلاین")]
        public int OnlineUsers { get; set; }

        [Display(Name = "پر بازدیدترین روز")]
        public string MaxDay { get; set; }
    }

    public partial class Statistic
    {
        public static void Insert(string browser)
        {
            using (ProjectModel context = new ProjectModel())
            {
                DateTime dt = DateTime.Now.Date;
                Statistic obj = context.Statistics.FirstOrDefault(item => item.Date == dt);

                if (obj == null)
                {
                    obj = new Statistic();
                }

                switch (browser)
                {
                    case "chrome":
                        obj.Chrome++;
                        break;
                    case "firefox":
                        obj.Firefox++;
                        break;
                    case "mozilla":
                        obj.Mozilla++;
                        break;
                    case "opera":
                        obj.Opera++;
                        break;
                    case "safari":
                        obj.Safari++;
                        break;
                    case "ie":
                    case "internetexplorer":
                        obj.IE++;
                        break;
                    case "blackberry":
                        obj.BlackBerry++;
                        break;
                    default:
                        obj.Unknown++;
                        break;
                }

                if (obj.ID == 0)
                {
                    context.Statistics.Add(obj);
                }

                context.SaveChanges();
            }
        }

        public static dynamic Select(int pageIndex, int pageSize, out int total)
        {
            using (ProjectModel context = new ProjectModel())
            {
                var query = from item in context.Statistics.AsEnumerable()
                            orderby item.Date descending
                            select new
                            {
                                Firefox = item.Firefox,
                                Chrome = item.Chrome,
                                IE = item.IE,
                                Opera = item.Opera,
                                Safari = item.Safari,
                                Mozilla = item.Mozilla,
                                BlackBerry = item.BlackBerry,
                                Unknown = item.Unknown,
                                Date = item.Date.ToPersianDate("d MMMM yyyy", false),
                                Count = item.Total
                            };
                total = query.Count();
                return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static SummaryStatisticVM Select()
        {
            using (ProjectModel context = new ProjectModel())
            {
                SummaryStatisticVM ss = new SummaryStatisticVM();
                DateTime date = DateTime.Now.Date;
                var query = (from item in context.Statistics
                             select item).ToList();

                ss.Today = (from item in query
                            where item.Date == date
                            select item.Total).Sum();

                DateTime dateTemp = date.AddDays(-1);
                ss.Yesterday = (from item in query
                                where item.Date == dateTemp
                                select item.Total).Sum();

                dateTemp = date.AddDays(-date.Day + 1);
                ss.Month = (from item in query
                            where item.Date >= dateTemp
                            select item.Total).Sum();

                dateTemp = date.AddDays(-date.Day + 1).AddMonths(-1);
                DateTime dateTemp2 = date.AddDays(-date.Day);
                ss.PrevMonth = (from item in query
                                where item.Date >= dateTemp && item.Date <= dateTemp2
                                select item.Total).Sum();

                dateTemp = date.AddDays(-date.DayOfYear + 1);
                ss.Year = (from item in query
                           where item.Date >= dateTemp
                           select item.Total).Sum();

                dateTemp = date.AddDays(-date.DayOfYear + 1).AddYears(-1);
                dateTemp2 = date.AddDays(-date.DayOfYear);
                ss.PrevYear = (from item in query
                               where item.Date >= dateTemp && item.Date <= dateTemp2
                               select item.Total).Sum();

                ss.Total = (from item in query
                            select item.Total).Sum();

                ss.OnlineUsers = Convert.ToInt32(HttpContext.Current.Application["OnlineUsers"]);

                var firstRecord = (from item in query
                                   orderby item.Total descending
                                   select item).FirstOrDefault();

                if (query != null)
                {
                    ss.MaxDay = firstRecord.Total + " نفر در " + firstRecord.Date.ToPersianDate("dddd d MMMM yyyy", false);
                }

                return ss;
            }
        }
    }
}