using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Branches = new HashSet<Branch>();
            FeeDetailFkcreatedbyNavigations = new HashSet<FeeDetail>();
            FeeDetailFkmodifiedByNavigations = new HashSet<FeeDetail>();
            Hostels = new HashSet<Hostel>();
            TenantBedMappingFkcreatedbyNavigations = new HashSet<TenantBedMapping>();
            TenantBedMappingFkmodifiedByNavigations = new HashSet<TenantBedMapping>();
            TenantFkcreatedbyNavigations = new HashSet<Tenant>();
            TenantFkmodifiedByNavigations = new HashSet<Tenant>();
        }

        public int PkuserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? FkroleId { get; set; }
        public string? Email { get; set; }

        public virtual Role? Fkrole { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<FeeDetail> FeeDetailFkcreatedbyNavigations { get; set; }
        public virtual ICollection<FeeDetail> FeeDetailFkmodifiedByNavigations { get; set; }
        public virtual ICollection<Hostel> Hostels { get; set; }
        public virtual ICollection<TenantBedMapping> TenantBedMappingFkcreatedbyNavigations { get; set; }
        public virtual ICollection<TenantBedMapping> TenantBedMappingFkmodifiedByNavigations { get; set; }
        public virtual ICollection<Tenant> TenantFkcreatedbyNavigations { get; set; }
        public virtual ICollection<Tenant> TenantFkmodifiedByNavigations { get; set; }
    }
}
