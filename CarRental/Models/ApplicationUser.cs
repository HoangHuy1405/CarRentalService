using CarRental.Models.ShareDrive;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRental.Models {
    public enum Role {
        User,
        Admin,
        Driver
    }
    public class ApplicationUser : IdentityUser {
        [ValidateNever]
        public IEnumerable<Vehicle> RentalVehicles { get; set; }
        [ValidateNever]
        public Driver? Driver { get; set; } // One-to-One relationship with Driver
        [ValidateNever]
        public ICollection<PassengerRide> PassengerRides { get; set; } // One-to-Many relationship with PassengerRide
        [ValidateNever]
        public float Balance { get; set; }

        public ApplicationUser() { 
            RentalVehicles = new List<Vehicle>();
            PassengerRides = new List<PassengerRide>();
        }
    }
}
