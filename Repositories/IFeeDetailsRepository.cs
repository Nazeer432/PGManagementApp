using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFeeDetailsRepository
    {
        Task<List<FeeDetail>> GetAll();
        Task<List<FeeDetail>> GetFeeDetailsByTenId(int tenantId);
        void AddFeeDetails(FeeDetail room);
        void UpdateFeeDetails(FeeDetail room);
        void DeleteFeeDetails(int id);
        Task<FeeDetail> GetFeeDetailsById(int id);
        string AcceptPayment(FeeDetail feeDetail);
        bool FeeDetailsExists(int id);
    }
}
