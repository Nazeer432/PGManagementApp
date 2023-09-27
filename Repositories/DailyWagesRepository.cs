using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Data.AppConstants;

namespace Repositories
{
    public class DailyWagesRepository : IDailyWagesRepository
    {
        private readonly HostelDBContext _context;
        public DailyWagesRepository(HostelDBContext context)
        {
            _context = context;
        }

        public void AddDailyWage(DailyWage dailyWage)
        {
            _context.DailyWages.Add(dailyWage);
            _context.SaveChanges();
        }

        public void DeleteDailyWage(int id)
        {
            throw new NotImplementedException();
        }

        public List<DailyWage> GetAll(int MonthId = 0, int YearId = 0, int FkbranchId = 0)
        {
            if (MonthId > 0 && YearId > 0 && FkbranchId > 0)
            {
                return _context.DailyWages.Where(i => i.Created.Value.Month == MonthId && i.Created.Value.Year == YearId && i.FkbranchId == FkbranchId).ToList();
            }
            else
            {
                return _context.DailyWages.ToList();
            }
        }

        public DailyWage GetDailyWageId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDailyWage(DailyWage dailyWage)
        {
            throw new NotImplementedException();
        }
    }
}
