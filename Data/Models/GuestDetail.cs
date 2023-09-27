using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Data.Models
{
    public partial class GuestDetail
    {
        public GuestDetail()
        {
            GuestUsers = new HashSet<GuestUser>();
        }
        [Key]
        public int GuestDetailId { get; set; }
        [Display(Name = "Id")]
        public string? GuestId { get; set; }
        [Display(Name = "Room")]
        public string? Room { get; set; }

        [Display(Name = "From")]
        public string From { get; set; }
        [Display(Name = "Purpose")]
        public byte? Purpose { get; set; }
        [Display(Name = "No Of Days")]
        public int NoOfDays { get; set; }
        [Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Check Out")]
        public DateTime CheckOut { get; set; }
        [Display(Name = "Payment Type")]
        public byte PaymentType { get; set; }
        [Display(Name = "Payment Status")]
        public byte? PaymentStatus { get; set; }
        [Display(Name = "Status")]
        public byte? Status { get; set; }
        [Display(Name = "Advance Amt")]
        public decimal? AdvanceAmount { get; set; }
        [Display(Name = "Total Amt")]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "Branch")]
        public int? FkbranchId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public virtual ICollection<GuestUser> GuestUsers { get; set; }
        public Branch? Fkbranch { get; set; }

    }
}
