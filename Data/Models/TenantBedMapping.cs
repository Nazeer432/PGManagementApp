using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class TenantBedMapping
    {
        public int PktenantBedId { get; set; }
        public int? FkbedId { get; set; }
        public int? FktenantId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? Fkcreatedby { get; set; }
        public int? FkmodifiedBy { get; set; }

        public virtual RoomBed? Fkbed { get; set; }
        public virtual UserProfile? FkcreatedbyNavigation { get; set; }
        public virtual UserProfile? FkmodifiedByNavigation { get; set; }
        public virtual Tenant? Fktenant { get; set; }
    }
}
