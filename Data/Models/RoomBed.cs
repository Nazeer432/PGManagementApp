using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class RoomBed
    {
        public RoomBed()
        {
            TenantBedMappings = new HashSet<TenantBedMapping>();
        }

        public int PkbedId { get; set; }
        public string BedName { get; set; } = null!;
        public byte? IsActive { get; set; }
        public int? FkroomId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Fkcreatedby { get; set; } = null!;
        public string FkmodifiedBy { get; set; } = null!;

        public virtual Room? Fkroom { get; set; }
        public virtual ICollection<TenantBedMapping> TenantBedMappings { get; set; }
    }
}
