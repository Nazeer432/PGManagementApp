using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Month
    {
        public int MonthId { get; set; }
        public string Name { get; set; }
    }
    public class Year
    {
        public int YearId { get; set; }
        public int Name { get; set; }
    }
    public static class Helper
    {
        public static List<Month> GetMonths()
        {
            List<Month> months = new List<Month>();
            months.Add(new Month {MonthId = 1, Name = "January" });
            months.Add(new Month {MonthId = 2, Name = "February" });
            months.Add(new Month {MonthId = 3, Name = "March" });
            months.Add(new Month {MonthId = 4, Name = "April" });
            months.Add(new Month {MonthId = 5, Name = "May" });
            months.Add(new Month {MonthId = 6, Name = "June" });
            months.Add(new Month {MonthId = 7, Name = "July" });
            months.Add(new Month {MonthId = 8, Name = "Auguest" });
            months.Add(new Month {MonthId = 9, Name = "September" });
            months.Add(new Month {MonthId = 10, Name = "October" });
            months.Add(new Month {MonthId = 11, Name = "November" });
            months.Add(new Month {MonthId = 12, Name = "December" });
            return months;
        }
        public static List<Year> GetYears()
        {
            List<Year> years = new List<Year>();
            years.Add(new Year { YearId = DateTime.Now.AddYears(-2).Year, Name = DateTime.Now.AddYears(-2).Year, });
            years.Add(new Year { YearId = DateTime.Now.AddYears(-1).Year, Name = DateTime.Now.AddYears(-1).Year, });
            years.Add(new Year { YearId = DateTime.Now.Year, Name = DateTime.Now.Year, });
            years.Add(new Year { YearId = DateTime.Now.AddYears(1).Year, Name = DateTime.Now.AddYears(1).Year, });

            return years;
        }
    }
}
