using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Data.AppConstants;

namespace Repositories
{
    public class FeeDetailsRepository : IFeeDetailsRepository
    {
        private readonly HostelDBContext _context;
        public FeeDetailsRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddFeeDetails(FeeDetail feeDetail)
        {
            try
            {
                // feeDetail.IsActive = true;
                feeDetail.Created = DateTime.Now;
                _context.FeeDetails.Add(feeDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void DeleteFeeDetails(int id)
        {
            try
            {
                FeeDetail feeDetail = await GetFeeDetailsById(id);
                //feeDetail.IsActive = false;
                feeDetail.Modified = DateTime.Now;
                _context.FeeDetails.Update(feeDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<FeeDetail>> GetAll()
        {
            return await _context.FeeDetails.ToListAsync();
        }
        public async Task<FeeDetail> GetFeeDetailsById(int id)
        {
            return await _context.FeeDetails.Include(x => x.Fktenant).ThenInclude(x => x.Fkroom).Where(x => x.PkfeeDetailsId == id).FirstOrDefaultAsync();
        }
        public void UpdateFeeDetails(FeeDetail feeDetail)
        {
            feeDetail.Modified = DateTime.Now;
            _context.FeeDetails.Update(feeDetail);
            _context.SaveChanges();
        }
        public bool FeeDetailsExists(int id)
        {
            return _context.FeeDetails.Any(e => e.PkfeeDetailsId == id);
        }
        public async Task<List<FeeDetail>> GetFeeDetailsByTenId(int tenantId)
        {
            return await _context.FeeDetails.Include(x => x.Fktenant).ThenInclude(i => i.Fkroom).Where(x => x.FktenantId == tenantId).ToListAsync();
        }

        public string AcceptPayment(FeeDetail feeDetail)
        {
            List<FeeDetail> feeDetailList = _context.FeeDetails.Where(x => x.FktenantId == feeDetail.FktenantId).ToList();
            int index = feeDetailList.FindIndex(nd => nd.PkfeeDetailsId == feeDetail.PkfeeDetailsId);
            try
            {
                List<FeeDetail> updateList = new List<FeeDetail>();
                _context.Database.BeginTransaction();
                double totalAmtToPay = (double)(feeDetail.FeeAmount + feeDetail.DueAmount.Value + feeDetail.FoodBill.Value + feeDetail.AdditionalAmount.Value);
                totalAmtToPay = Math.Round(totalAmtToPay, 2);
                if ((double)feeDetail.ReceivedAmount != totalAmtToPay && (double)feeDetail.ReceivedAmount < totalAmtToPay)
                {
                    FeeDetail nxtFeeDetail = feeDetailList.ElementAt(index + 1);
                    nxtFeeDetail.DueAmount = (decimal)totalAmtToPay - feeDetail.ReceivedAmount;
                    updateList.Add(nxtFeeDetail);
                }
                updateList.Add(feeDetail);
                _context.FeeDetails.UpdateRange(updateList);
                _context.SaveChanges();
                _context.Database.CommitTransaction();
                return "Payment details saved successfully..!!";
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                return "Issue in saving payment..!!";
            }
        }
    }
}
