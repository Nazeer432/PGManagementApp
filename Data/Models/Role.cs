using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Role
    {
        public Role()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        public int PkroleId { get; set; }
        public string RoleName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
