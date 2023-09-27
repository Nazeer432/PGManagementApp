using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Data.Models
{
    public partial class DailyWage
    {
        public DailyWage()
        {

        }
        [Key]
        public int PKDailyWageId { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Wage type")]
        public byte WageType { get; set; }
        public byte Status { get; set; }
        public string Note { get; set; }
        [Display(Name = "Paid By")]
        public string? PaidBy { get; set; }
        public int? FkbranchId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public int? Fkcreatedby { get; set; }
        public int? FkmodifiedBy { get; set; }
        [Display(Name = "Branch")]
        public Branch? Fkbranch { get; set; }
        [Display(Name = "Hostel")]
        public Hostel? Fkhostel { get; set; }
        public virtual UserProfile? FkcreatedbyNavigation { get; set; }
        public virtual UserProfile? FkmodifiedByNavigation { get; set; }
        [NotMapped]
        public int MonthId { get; set; }
        [NotMapped]
        public int YearId { get; set; }
    }
}
