using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models {
    public class RentalVehicle {
        public int RentalVehicleID { get; set; } //pk

		[ValidateNever]
		public string OwnerId { get; set; } //fk
		[ValidateNever]
        public ApplicationUser? Owner { get; set; }

		[Required(ErrorMessage = "License Plate is required.")]
		public string LicensePlate { get; set; }
		[Required(ErrorMessage = "Brand is required.")]
		public string Brand { get; set; }
		[Required(ErrorMessage = "Model is required.")]
		public string Model { get; set; }

		[Required(ErrorMessage = "Manufacture Year is required.")]
        public DateTime ManuYear { get; set; }
		[Required(ErrorMessage = "Number of seats is required.")]
        public int NumberOfSeats { get; set; }
		[StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
		public string ?Description { get; set; }
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Fee Per Day must be a positive number.")]
		public float RentalFeePerDay { get; set; }
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Fee Per Kilo must be a positive number.")]
		public float RentalFeePerKilo { get; set; }
		public DateTime TimeCreated { get; set; } = DateTime.Now;

		[Required]
		[NotMapped]
		public IFormFile? ThumbnailImage { get; set; }
		public string ThumbnailUrl { get; set; } = "https://via.placeholder.com/150";

		[Required]
		[NotMapped]
        public List<IFormFile>? ImageGallery { get; set; }
		[ValidateNever]
		public List<CarImage> Gallery { get; set; }
	}
}
