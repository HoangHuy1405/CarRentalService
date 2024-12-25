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

        public ApplicationUser() { 
            RentalVehicles = new List<Vehicle>();
        }
    }
}
