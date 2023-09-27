using Data;
using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.ApplicationEnums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using static Data.AppConstants;

namespace Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly HostelDBContext _context;
        public TenantRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddTenant(TenantsDb tenant)
        {
            try
            {
                _context.Database.BeginTransaction();
                Room room = _context.Rooms.Where(x => x.PkroomId == tenant.FkRoomId).FirstOrDefault();
                if (room != null)
                {
                    if (room.RoomStatus != (byte)RoomStatus.Filled)
                    {
                        int filledBeds = room.FilledBeds.HasValue ? room.FilledBeds.Value : 0;
                        room.FilledBeds = filledBeds + 1;
                        if (room.NumberOfBeds == room.FilledBeds)
                        {
                            room.RoomStatus = (byte)RoomStatus.Filled;
                        }
                        _context.Update(room);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Room already filled..!!");
                    }
                }
                Tenant objTenant = new Tenant();
                objTenant.TenantName = tenant.TenantName;
                objTenant.Age = tenant.Age;
                objTenant.Gender = tenant.Gender;
                objTenant.MobileNo = tenant.MobileNo;
                objTenant.EmailId = tenant.EmailId;
                objTenant.Designation = tenant.Designation;
                objTenant.PhotoUrl = tenant.PhotoUrl;
                objTenant.ProofName = tenant.ProofName;
                objTenant.ProofId = tenant.ProofId;
                objTenant.OfficeAddress = tenant.OfficeAddress;
                objTenant.HomeAddress = tenant.HomeAddress;
                objTenant.RegisteredDate = tenant.RegisteredDate;
                objTenant.FkroomId = tenant.FkRoomId;
                objTenant.MonthlyFee = tenant.MonthlyFee ?? decimal.Zero;
                objTenant.AdvancePayment = tenant.AdvancePayment;
                objTenant.FoodCard = tenant.FoodCard;
                objTenant.IsCoLiveIn = tenant.IsCoLiveIn;
                objTenant.IsActive = (byte)TenantStatus.Active;
                objTenant.Created = DateTime.Now;
                objTenant.MasterId = tenant.PrimaryTenant;

                _context.Tenants.Add(objTenant);
                _context.SaveChanges();
                DateTime StartDate = tenant.RegisteredDate.Value;
                int NoOfMnthsCurYer = 10;
                List<FeeDetail> feeDetails = new List<FeeDetail>();
                //Generating FeeDetails structure  
                if (objTenant.MonthlyFee > decimal.Zero)
                {
                    //Tenant wants to pay fee on first day of the next month
                    if (tenant.AdjustMonth)
                    {
                        int countDays = DateTime.DaysInMonth(StartDate.Year, StartDate.Month) - StartDate.Day;
                        decimal? feeAmount = Convert.ToDecimal((objTenant.MonthlyFee / 30) * countDays);

                        decimal foodBill = decimal.Zero;
                        if (tenant.FoodCardAmount > decimal.Zero)
                        {
                             foodBill = Convert.ToDecimal((tenant.FoodCardAmount / 30) * countDays);
                        }
                       
                        DateTime lastDayOfMonth = new DateTime(StartDate.Year, StartDate.Month, DateTime.DaysInMonth(StartDate.Year, StartDate.Month));
                        StartDate = new DateTime(StartDate.Year, StartDate.Month, 1).AddMonths(1);
                        feeDetails.Add(new FeeDetail()
                        {
                            FeeAmount = objTenant.MonthlyFee,
                            DueAmount = decimal.Zero,
                            FeeDate = StartDate,
                            Created = DateTime.Now,
                            FktenantId = objTenant.PktenantId,
                            Status = (byte)PaymentStatus.NotPaid,
                            AdditionalAmount = decimal.Zero,
                            FoodBill = foodBill
                        });
                        StartDate = new DateTime(StartDate.Year, StartDate.Month, 1).AddMonths(1);
                    }
                    for (int i = 1; i <= NoOfMnthsCurYer; i++)
                    {
                        FeeDetail feeDetail = new FeeDetail()
                        {
                            FeeAmount = objTenant.MonthlyFee,
                            DueAmount = decimal.Zero,
                            FeeDate = StartDate.AddMonths(i),
                            Created = DateTime.Now,
                            FktenantId = objTenant.PktenantId,
                            Status = (byte)PaymentStatus.NotPaid,
                            AdditionalAmount = decimal.Zero,
                            FoodBill = tenant.FoodCardAmount ?? decimal.Zero
                        };
                        feeDetails.Add(feeDetail);
                    }
                    _context.FeeDetails.AddRange(feeDetails);
                    _context.SaveChanges();
                }
                _context.Database.CommitTransaction();

            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw ex;
            }
        }
        public void DeleteTenant(int id)
        {
            try
            {
                Tenant tenant = GetTenantById(id);
                if (tenant != null)
                {
                    tenant.IsActive = (byte)TenantStatus.Deleted;
                    tenant.Modified = DateTime.Now;
                    _context.Tenants.Update(tenant);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Tenant>> GetAll()
        {
            return await _context.Tenants.ToListAsync();
        }
        public List<TenantsDb> GetAllTenantsByStatus()
        {
            List<TenantsDb> tenantsViews = new List<TenantsDb>();
            try
            {
                List<Tenant> lstTenants = _context.Tenants.Include(x => x.Fkroom).Include(i => i.FeeDetails).Where(y => y.IsActive == (int)TenantStatus.Active).ToList();
                foreach (var item in lstTenants)
                {
                    TenantsDb tenantsView = new TenantsDb();
                    tenantsView.PktenantId = item.PktenantId;
                    tenantsView.TenantName = item.TenantName;
                    tenantsView.MobileNo = item.MobileNo;
                    tenantsView.RoomName = item.Fkroom.RoomName + " | " + @Enum.GetName(typeof(RoomType), item.Fkroom.RoomType);
                    tenantsView.IsActive = item.IsActive;
                    if (item.FeeDetails.Count > 0)
                    {


                        if (item.FeeDetails.Any(i => i.FeeDate.Value.Month == DateTime.Now.Month))
                        {
                            var feeDetais = item.FeeDetails.Where(x => x.FeeDate.Value.Month == DateTime.Now.Month).FirstOrDefault();
                            tenantsView.MonthlyFee = feeDetais.FeeAmount + feeDetais.DueAmount + feeDetais.FoodBill ?? decimal.Zero + feeDetais.AdditionalAmount;
                            tenantsView.DueDate = feeDetais.FeeDate.Value;
                            tenantsView.PaidDate = feeDetais.PaidDate.HasValue ? feeDetais.PaidDate.Value : DateTime.MinValue;
                            tenantsView.FeeStatus = feeDetais.Status.Value;
                        }
                        else if (item.FeeDetails.Any(i => i.FeeDate.Value.Month == DateTime.Now.AddMonths(1).Month))
                        {
                            var feeDetais = item.FeeDetails.Where(x => x.FeeDate.Value.Month == DateTime.Now.AddMonths(1).Month).FirstOrDefault();
                            tenantsView.MonthlyFee = feeDetais.FeeAmount + feeDetais.DueAmount + feeDetais.FoodBill + feeDetais.AdditionalAmount;
                            tenantsView.DueDate = feeDetais.FeeDate.Value;
                            tenantsView.PaidDate = feeDetais.PaidDate.HasValue ? feeDetais.PaidDate.Value : DateTime.MinValue;
                            tenantsView.FeeStatus = feeDetais.Status.Value;
                        }
                        else
                        {
                            var feeDetais = item.FeeDetails.Where(x => x.Status == (byte)PaymentStatus.NotPaid).FirstOrDefault();
                            tenantsView.MonthlyFee = feeDetais.FeeAmount + feeDetais.DueAmount + feeDetais.FoodBill + feeDetais.AdditionalAmount;
                            tenantsView.DueDate = feeDetais.FeeDate.Value;
                            tenantsView.PaidDate = feeDetais.PaidDate.HasValue ? feeDetais.PaidDate.Value : DateTime.MinValue;
                            tenantsView.FeeStatus = feeDetais.Status.Value;
                        }
                    }
                    else
                    {
                        tenantsView.MonthlyFee = decimal.Zero;
                        tenantsView.DueDate = DateTime.MinValue;
                        tenantsView.PaidDate = DateTime.MinValue;
                        tenantsView.FeeStatus = (byte)PaymentStatus.None;
                    }
                    tenantsViews.Add(tenantsView);
                }
                return tenantsViews;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tenantsViews;
        }

        public Tenant GetTenantById(int id)
        {
            return _context.Tenants.Find(id);
        }
        public async Task<TenantsDb> GetTenantEditById(int id)
        {
            Tenant objTenant = await _context.Tenants.Include(i => i.FeeDetails).FirstOrDefaultAsync(x => x.PktenantId == id);
            TenantsDb tenantsDb = new TenantsDb();
            tenantsDb.PktenantId = objTenant.PktenantId;
            tenantsDb.TenantName = objTenant.TenantName;
            tenantsDb.Age = objTenant.Age;
            tenantsDb.Gender = objTenant.Gender;
            tenantsDb.MobileNo = objTenant.MobileNo;
            tenantsDb.EmailId = objTenant.EmailId;
            tenantsDb.Designation = objTenant.Designation;
            tenantsDb.RegisteredDate = objTenant.RegisteredDate;
            tenantsDb.MonthlyFee = objTenant.MonthlyFee;
            tenantsDb.AdvancePayment = objTenant.AdvancePayment;
            tenantsDb.FkRoomId = objTenant.FkroomId;
            tenantsDb.FkOldRoomId = objTenant.FkroomId;
            tenantsDb.ProofName = objTenant.ProofName;
            tenantsDb.ProofId = objTenant.ProofId;
            tenantsDb.PhotoUrl = objTenant.PhotoUrl;
            tenantsDb.HomeAddress = objTenant.HomeAddress;
            tenantsDb.OfficeAddress = objTenant.OfficeAddress;
            tenantsDb.HomeAddress = objTenant.HomeAddress;
            tenantsDb.FoodCard = objTenant.FoodCard;
            tenantsDb.Created = objTenant.Created;
            tenantsDb.Modified = objTenant.Modified;
            // tenantsDb.FoodCardAmount = objTenant.FeeDetails.FirstOrDefault().FoodBill;

            return tenantsDb;
        }
        public void UpdateTenant(TenantsDb tenant)
        {
            try
            {
                _context.Database.BeginTransaction();
                if (tenant.FkOldRoomId != tenant.FkRoomId)
                {
                    Room oldRoom = _context.Rooms.Where(x => x.PkroomId == tenant.FkOldRoomId).FirstOrDefault();
                    if (oldRoom != null)
                    {

                        int filledBeds = oldRoom.FilledBeds.HasValue ? oldRoom.FilledBeds.Value : 0;
                        oldRoom.FilledBeds = filledBeds - 1;
                        if (oldRoom.NumberOfBeds == oldRoom.FilledBeds)
                        {
                            oldRoom.RoomStatus = (byte)RoomStatus.Filled;
                        }
                        _context.Update(oldRoom);
                        _context.SaveChanges();
                    }

                    Room newRoom = _context.Rooms.Where(x => x.PkroomId == tenant.FkRoomId).FirstOrDefault();
                    int filledBed = newRoom.FilledBeds.HasValue ? newRoom.FilledBeds.Value : 0;
                    newRoom.FilledBeds = filledBed + 1;
                    if (newRoom.NumberOfBeds == newRoom.FilledBeds)
                    {
                        newRoom.RoomStatus = (byte)RoomStatus.Filled;
                    }
                    _context.Update(newRoom);
                    _context.SaveChanges();
                }

                Tenant objTenant = new Tenant();
                objTenant.PktenantId = tenant.PktenantId;
                objTenant.TenantName = tenant.TenantName;
                objTenant.Age = tenant.Age;
                objTenant.Gender = tenant.Gender;
                objTenant.MobileNo = tenant.MobileNo;
                objTenant.EmailId = tenant.EmailId;
                objTenant.Designation = tenant.Designation;
                objTenant.PhotoUrl = tenant.PhotoUrl;
                objTenant.ProofName = tenant.ProofName;
                objTenant.ProofId = tenant.ProofId;
                objTenant.OfficeAddress = tenant.OfficeAddress;
                objTenant.HomeAddress = tenant.HomeAddress;
                objTenant.RegisteredDate = tenant.RegisteredDate;
                objTenant.FkroomId = tenant.FkRoomId;
                objTenant.MonthlyFee = tenant.MonthlyFee;
                objTenant.AdvancePayment = tenant.AdvancePayment;
                objTenant.FoodCard = tenant.FoodCard;
                objTenant.IsCoLiveIn = tenant.IsCoLiveIn;
                objTenant.IsActive = (byte)TenantStatus.Active;
                objTenant.Created = tenant.Created;
                objTenant.Modified = DateTime.Now;

                _context.Tenants.Update(objTenant);
                _context.SaveChanges();
                _context.Database.CommitTransaction();

            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw ex;
            }
        }
        public bool TenantExists(int id)
        {
            return _context.Tenants.Any(e => e.PktenantId == id);
        }

        public List<SelectListItem> GetAllPrimaryTenants()
        {
            List<Tenant> lstTenants = _context.Tenants.Where(y => y.IsActive == (int)TenantStatus.Active || y.IsActive == (int)TenantStatus.OnNoticePeriod).ToList();
            // return lstTenants;
            List<SelectListItem> listData = new List<SelectListItem>();
            listData.Add(new SelectListItem
            {
                Text = "-None-",
                Value = "0",
            });

            foreach (var item in lstTenants)
            {
                listData.Add(new SelectListItem
                {
                    Text = item.TenantName,
                    Value = item.PktenantId.ToString()
                });
            }
            return listData;
        }
    }
}
