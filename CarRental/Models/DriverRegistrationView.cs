using System.ComponentModel.DataAnnotations;

namespace CarRental.Models {
    public class DriverRegistrationView {
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }

        [Required]
        public IFormFile? LicenseImg { get; set; }

        [Required]
        public IFormFile? NationalIdImg { get; set; }
    }
}
