using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class FeeDetail
    {
        public int PkfeeDetailsId { get; set; }
        [Display(Name = "Fees")]
        public decimal? FeeAmount { get; set; }
        [Display(Name = "Due Amount")]
        public decimal? DueAmount { get; set; }
        public DateTime? FeeDate { get; set; }
        [Display(Name ="Payment Type")]
        public byte? FeeMode { get; set; }
        [Display(Name = "Received Amount")]
        public decimal? ReceivedAmount { get; set; }
        [Display(Name = "Transaction No")]
        public string? TransactionType { get; set; }
        public int? FktenantId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? Fkcreatedby { get; set; }
        public int? FkmodifiedBy { get; set; }
        public decimal? AdditionalAmount { get; set; }
        public byte? Status { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal? FoodBill { get; set; }
        public string? Note { get; set; }

        public virtual UserProfile? FkcreatedbyNavigation { get; set; }
        public virtual UserProfile? FkmodifiedByNavigation { get; set; }
        public virtual Tenant? Fktenant { get; set; }
    }
}
