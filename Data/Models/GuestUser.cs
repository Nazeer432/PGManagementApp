using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Data.ApplicationEnums;

namespace Data.Models
{
    public partial class GuestUser
    {
        public GuestUser()
        {
          
        }
        [Key]
        public int GuestUserId { get; set; }
      
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Contact No")]
        public long? ContactNumber { get; set; }
        [Display(Name = "Proof Name")]
        public byte? ProofName { get; set; }
        [Display(Name = "Proof Id")]
        public string ProodId { get; set; }
    
        [Display(Name = "Status")]
        public byte? Status { get; set; }
        [Display(Name = "Branch")]
        public int? FkGuestDetailId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
       
        public GuestDetail? FkGuestDetail { get; set; }
       
    }
}
