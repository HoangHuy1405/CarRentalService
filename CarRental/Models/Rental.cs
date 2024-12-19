using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CarRental.Models {
    public enum Status {
        Pending,
        Confirmed,
        Cancelled,
    }
    public class Rental {
        public int? RentalId { get; set; }

        
        public string? UserID { get; set; } //fk
        [ValidateNever]
        public ApplicationUser User { get; set; }

        public int? RentalVehicleID { get; set; }   //fk
        [ValidateNever]
        public RentalVehicle RentalVehicle { get; set; }

        [Required(ErrorMessage = "Date Start is required.")]
		[Display(Name = "Date Start")]
		public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Date End is required.")]
        [Display(Name = "Date End")]
		public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Pick Up Location is required.")]
        [Display(Name = "Pick Up Location")]
        public string PickUpLocation { get; set; }

        public float totalFee { get; set; }
        public float depositFee { get; set; }


        public Status Status { get; set; } = Status.Pending;
    }
}
