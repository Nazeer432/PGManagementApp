using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Data.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomBeds = new HashSet<RoomBed>();
            Tenants = new HashSet<Tenant>();
        }

        public int PkroomId { get; set; }
        [Display(Name = "Room Name")]
        public string RoomName { get; set; } = null!;
        [Display(Name = "Status")]
        public byte? RoomStatus { get; set; }
        [Display(Name = "Branch")]
        public int? FkbranchId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        [Display(Name = "Hostel")]
        public int FkhostelId { get; set; }
        [Display(Name = "Total Beds")]
        public int? NumberOfBeds { get; set; }
        [Display(Name = "Guest Room")]
        public bool IsGuestRoom { get; set; }
        [Display(Name = "Room Type")]
        public byte? RoomType { get; set; }
        [Display(Name = "Filled Beds")]
        public int? FilledBeds { get; set; }

        public virtual ICollection<RoomBed> RoomBeds { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public Branch? Fkbranch { get; set; }
        public Hostel? Fkhostel { get; set; }
    }
}
