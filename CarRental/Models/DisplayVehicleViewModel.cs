namespace CarRental.Models {
    public class DisplayVehicleViewModel {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public string ButtonText { get; set; } = "View Details"; // Default button text
        public string ButtonClass { get; set; } = "btn btn-primary"; // Default button style
        public string ButtonActionUrl { get; set; } // Optional URL for the button
    }
}
