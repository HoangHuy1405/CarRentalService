using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.ShareDrive {
    public class PassengerRide {
        [Key]
        public int PassengerRideID { get; set; }

        [ForeignKey(nameof(Passenger))] // Defines it as a foreign key to ApplicationUser
        public string PassengerID { get; set; }
        [ValidateNever]
        public ApplicationUser? Passenger { get; set; }

        [ForeignKey(nameof(Driver))] // Defines it as a foreign key to ApplicationUser
        public string DriverID { get; set; }
        [ValidateNever]
        public ApplicationUser? Driver { get; set; }

        [Required]
        [Display(Name = "Starting location")]
        public string StartLocation { get; set; }
        [Required]
        [Display(Name = "Ending location")]
        public string EndLocation { get; set; }
        [Required]
        [Display(Name = "Number of seats available")]
        public int Seats { get; set; }
        [Required]
        [Display(Name = "Departure time")]
        public TimeOnly? DepartTime { get; set; }
        [Required]
        [Display(Name = "Departure date")]
        public DateTime? DepartDate { get; set; }
    }
}
