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
        public string DriverRideID { get; set; }

        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Seats { get; set; }
        public TimeOnly? DepartTime { get; set; }
        public DateTime? DepartDate { get; set; }
    }
}
