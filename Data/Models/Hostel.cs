using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Hostel
    {
        public Hostel()
        {
            Branches = new HashSet<Branch>();
        }

        public int PkhostelId { get; set; }
        public string HostelName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? FkcreatedBy { get; set; }

        public virtual UserProfile? FkcreatedByNavigation { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
