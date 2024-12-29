using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CarRental.Models.ShareDrive;

namespace CarRental.Models {
    public class Driver {
        [Key]
		[ForeignKey(nameof(User))] // Defines it as a foreign key to ApplicationUser
		public string? UserID { get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }

        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public DateTime LicenseExpiryDate { get; set; }

        public string? LicenseImageUrl { get; set; } = "https://via.placeholder.com/150";
        public string? NationalIdUrl { get; set; } = "https://via.placeholder.com/150";

        [ValidateNever]
        public ICollection<DriverRide> DriverRides { get; set; } // One-to-Many relationship with DriverRide

        public DriverStatus Status { get; set; } = DriverStatus.Pending; // Default status
    }
    public enum DriverStatus {
        Pending,
        Approved,
        Rejected
    }
}
