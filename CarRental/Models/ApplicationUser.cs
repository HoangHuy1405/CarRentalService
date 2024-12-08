using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRental.Models {
    public enum Role {
        User,
        Renter,
        Owner
    }
    public class ApplicationUser : IdentityUser {
        // inherit attribute from IdentityUser(id, email, name, ...)
        public Role Role { get; set; } = Role.User;
        [ValidateNever]
        public IEnumerable<RentalVehicle> RentalVehicles { get; set; }

        public ApplicationUser() { 
            RentalVehicles = new List<RentalVehicle>();
        }
    }
}
