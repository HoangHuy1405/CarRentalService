using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Models {
	public enum Transmission {
        Manual,
        Automatic
    }
	public enum FuelType {
		Petrol,
		Diesel,
		Electric,
		Hybrid
	}
    public class RentalVehicle {
		[Key]
        public int RentalVehicleID { get; set; } //pk

		[ValidateNever]
		public string OwnerId { get; set; } //fk
		[ValidateNever]
        public ApplicationUser? Owner { get; set; }

		[Display(Name = "License Plate")]
		[Required(ErrorMessage = "License Plate is required.")]
		public string LicensePlate { get; set; }
		[Required(ErrorMessage = "Brand is required.")]
		public string Brand { get; set; }
		[Required(ErrorMessage = "Model is required.")]
		public string Model { get; set; }

		[Display(Name = "Manufacture Year")]
		[Required(ErrorMessage = "Manufacture Year is required.")]
        public DateTime ManuYear { get; set; }
		[Display(Name = "Number Of Seats")]
		[Required(ErrorMessage = "Number of seats is required.")]
        public int NumberOfSeats { get; set; }

		[StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters.")]
		public string ?Description { get; set; }

		[Display(Name = "Rental Fee Per Day")]
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Fee Per Day must be a positive number.")]
		public float RentalFeePerDay { get; set; }

		[Display(Name = "Rental Fee Per Hour")]
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Fee Per Hour must be a positive number.")]
		public float RentalFeePerKilo { get; set; }
		public DateTime TimeCreated { get; set; } = DateTime.Now;

		public String Location { get; set; }
		[Display(Name = "Fuel Type")]
		public FuelType FuelType { get; set; }
		public Transmission Transmission { get; set; }
		[Display(Name = "Fuel Consumption")]
		public float FuelConsumption {  get; set; } // tieu hoa nhien lieu 1 lit/100km

        // additional condition and features (maybe)
        /*
Vehicle Condition (e.g., Excellent, Good, Fair)
Odometer Reading (total distance traveled by the car)
Air Conditioning (Yes/No)
GPS Navigation System (Yes/No)
Bluetooth/Audio System (Yes/No)
Child Seat Availability (Yes/No)
Safety Features (e.g., Airbags, ABS, Lane Assist)
		 */

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
