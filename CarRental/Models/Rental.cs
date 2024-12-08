namespace CarRental.Models {
    public enum Status {
        Pending,
        Confirmed,
        Cancelled,
    }
    public class Rental {
        public int? RentalId { get; set; }

        public string? UserID { get; set; } //fk
        public ApplicationUser User { get; set; }

        public int? RentalVehicleID { get; set; }   //fk
        public RentalVehicle RentalVehicle { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }
}
