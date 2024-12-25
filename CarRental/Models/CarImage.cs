using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models {
	public class CarImage {
		public string CarImageID { get; set; }			//pk

		public int RentalVehicleID { get; set; }		//fk
		public Vehicle RentalVehicle { get; set; }

		public string ImageUrl { get; set; } = "https://via.placeholder.com/150";

	}
}
