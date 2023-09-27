using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationEnums
    {
        public enum RoomType
        {
            AC = 1,
            [Display(Name = "Non-Ac")]
            NonAc = 2
        }
        public enum RoomStatus
        {
            Avaliable = 1,
            [Display(Name = "Half-Filled")]
            HalfFilled = 2,
            Filled = 3,
            [Display(Name = "Delete")]
            Delete = 4
        }
        public enum FoodCard
        {
            [Display(Name = "Not Taken")]
            NotTaken = 1,
            Taken = 2,
            Cancel = 3
        }
        public enum TenantStatus
        {
            [Display(Name = "Active")]
            Active = 1,
            [Display(Name = "On Notice Period")]
            OnNoticePeriod =2,
            [Display(Name = "Settled")]
            SettledOut = 3,
            [Display(Name = "Left Pg")]
            LeftPg = 4,
            Hold = 5,
            [Display(Name = "Delete")]
            Deleted = 5
        }
        public enum PaymentStatus
        {
            [Display(Name = "Not Paid")]
            NotPaid = 1,
            [Display(Name = "On-Time Payment")]
            OnTimePaid = 2,
            [Display(Name = "Late Payment")]
            LatePayment = 3,
            [Display(Name = "Partially Payment")]
            PartiallyPaid = 4,
            None = 5
        }
        public enum TransactionType
        {
            None = 0,
            Cash = 1,
            [Display(Name = "Phone Pay")]
            PhonePay = 2,
            [Display(Name = "Google Pay")]
            GooglePay = 3,
            Card = 4,
            Paytm = 5,
            Other = 6
        }
        public enum GuestPurpose
        {
            Visting = 1,
            [Display(Name = "Personal Work")]
            PersonalWork = 2,
            [Display(Name = "Office Work")]
            OfficeWork = 3,
            [Display(Name = "Business Work")]
            BusinessWork = 4,
            [Display(Name = "Family Function")]
            FamilyFunction = 5,
            Occasion = 6,
            Other = 7
        }
        public enum Gender
        {
            Male = 1,
            FeMale = 2,
            Other = 3
        }
        public enum LiveType
        {
            Single = 1,
            Couple = 2
        }
        public enum ProofName
        {
            Aadhar = 1,
            [Display(Name = "Pan Card")]
            PanCard = 2,
            [Display(Name = "Voter Id")]
            VoterId = 3,
            Passport = 4,
            [Display(Name = "Drviing License")]
            DrviingLicence = 5,
            [Display(Name = "Office Id")]
            EmployerIdCard
        }
        public enum Designation
        {
            Employee = 1,
            Student = 2,
            Business = 3,
            Training = 4,
            None = 5
        }
        
        public enum WageType
        {
            
            [Display(Name = "Grocery Items")]
            GroceryItems = 1,
            [Display(Name = "Dairy Products")]
            DairyProducts = 2,
            [Display(Name = "Beverages")]
            Beverages = 3,
            [Display(Name = "Water Tank Bill")]
            WaterTank = 4,
            [Display(Name = "Drinking Water Bill")]
            DrinkingWater = 5,
           [Display(Name = "Cook Salary")]
            CookSalary = 6,
            [Display(Name = "MaidCharges")]
            MaidCharges = 7,
            [Display(Name = "Room Boy Charge")]
            RoomBoyCharge = 8,
            Rent = 9,
            [Display(Name = "Current Bill")]
            CurrentBill = 10,
            [Display(Name = "Internet Bill")]
            InternetBill = 11,
            Vegitables = 12,
            [Display(Name = "Laundry Charge")]
            LaundryCharge = 13,
            Plumber = 14,
            Other = 15
        }

       

    }
}
