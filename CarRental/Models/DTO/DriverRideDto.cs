namespace CarRental.Models.DTO {
    public class DriverRideDto {
        public int DriverRideID { get; set; }
        public string DriverID { get; set; }
        public string DriverName { get; set; }
        public string DriverEmail { get; set; }
        public string DriverPhone { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public string? LicenseImageUrl { get; set; } = "https://via.placeholder.com/150";
        public string? NationalIdUrl { get; set; } = "https://via.placeholder.com/150";

        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime? DepartDate { get; set; }
        public TimeOnly? DepartTime { get; set; }
        public int Seats { get; set; }
        public int SeatLeft { get; set; }
    }
}
