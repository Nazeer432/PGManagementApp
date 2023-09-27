//using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.ViewModels
{
    public class TenantsDb
    {
        public int PktenantId { get; set; }
        [Display(Name = "Name")]
        public string TenantName { get; set; } = null!;
        [Display(Name = "Mobile No")]
        public long MobileNo { get; set; }
        [Display(Name = "Email Id")]
        public string? EmailId { get; set; } = null!;
        [Display(Name = "Photo")]
        public string? PhotoUrl { get; set; }
        [Display(Name = "Proof Name")]
        public string ProofName { get; set; } = null!;
        [Display(Name = "Proof Id")]
        public string ProofId { get; set; } = null!;
        public string? Designation { get; set; }
        [Display(Name = "Office Address")]
        public string? OfficeAddress { get; set; }
        [Display(Name = "Home Address")]
        public string? HomeAddress { get; set; }
        [Display(Name = "Register Date")]
        public DateTime? RegisteredDate { get; set; }
        [Display(Name = "Monthly Fee")]
        public decimal? MonthlyFee { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        [Display(Name = "Stay type")]
        public byte IsCoLiveIn { get; set; }
        public byte? IsActive { get; set; }
        [Display(Name = "Document url")]
        public string? DocumentUrl { get; set; }
        [Display(Name = "Advance Amount")]
        public decimal? AdvancePayment { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? Fkcreatedby { get; set; }
        public int? FkmodifiedBy { get; set; }
        [Display(Name = "Room")]
        public int FkRoomId { get; set; }
        public int FkOldRoomId { get; set; }
        [Display(Name = "Food Card")]
        public byte FoodCard { get; set; }
        [Display(Name = "Food Fee")]
        public decimal? FoodCardAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaidDate { get; set; }
        public byte FeeStatus { get; set; }
        [Display(Name = "Room")]
        public string? RoomName { get; set; }
        public int PrimaryTenant { get; set; }
        [Display(Name = "Adjust First Month")]
        public bool AdjustMonth { get; set; }
        public bool? StructureClosed { get; set; }
        //public List<FeeDetail>? lstFeeDetails { get; set; }
    }




}
