namespace CarRental.Models.DTO {
    public class PassengerRideDto {
        public int PassengerRideID { get; set; }
        public string PassengerName { get; set; }  // Only the name of the passenger
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Seats { get; set; }
        public DateTime? DepartDate { get; set; }
        public TimeOnly? DepartTime { get; set; }
        public float TotalFee { get; set; }
        public Status Status { get; set; }  // Show status like Pending, Confirmed, etc.
    }
}
