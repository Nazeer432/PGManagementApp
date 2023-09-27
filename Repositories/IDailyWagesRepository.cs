using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDailyWagesRepository
    {
        List<DailyWage> GetAll(int MonthId = 0, int YearId = 0, int FkbranchId = 0);
        void AddDailyWage(DailyWage dailyWage);
        void UpdateDailyWage(DailyWage dailyWage);
        void DeleteDailyWage(int id);
        DailyWage GetDailyWageId(int id);
    }
}
