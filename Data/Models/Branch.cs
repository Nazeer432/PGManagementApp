using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Branch
    {
        public int PkbranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string Location { get; set; } = null!;
        public int? FkcreatedBy { get; set; }
        public int? FkhostelId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual UserProfile? FkcreatedByNavigation { get; set; }
        public virtual Hostel? Fkhostel { get; set; }
    }
}
