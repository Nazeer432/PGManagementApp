using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            FeeDetails = new HashSet<FeeDetail>();
            TenantBedMappings = new HashSet<TenantBedMapping>();
        }

        public int PktenantId { get; set; }
        public string TenantName { get; set; } = null!;
        public long MobileNo { get; set; }
        public string? EmailId { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string ProofName { get; set; } = null!;
        public string ProofId { get; set; } = null!;
        public string? Designation { get; set; }
        public string? OfficeAddress { get; set; }
        public string? HomeAddress { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public decimal? MonthlyFee { get; set; }
        public byte? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? Fkcreatedby { get; set; }
        public int? FkmodifiedBy { get; set; }
        public string? DocumentUrl { get; set; }
        public decimal? AdvancePayment { get; set; }
        public int Age { get; set; }
        public byte IsCoLiveIn { get; set; }
        public int FkroomId { get; set; }
        public byte FoodCard { get; set; }
        public string? Gender { get; set; }
        public DateTime? LastDate { get; set; }
        public int MasterId { get; set; }
        public virtual UserProfile? FkcreatedbyNavigation { get; set; }
        public virtual UserProfile? FkmodifiedByNavigation { get; set; }
        public virtual Room Fkroom { get; set; } = null!;
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
        public virtual ICollection<TenantBedMapping> TenantBedMappings { get; set; }
    }
}
