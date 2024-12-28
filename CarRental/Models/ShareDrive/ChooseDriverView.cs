namespace CarRental.Models.ShareDrive {
    public class ChooseDriverView {
        public IEnumerable<DriverRide> Drivers { get; set; }
        public PassengerRideView passenger { get; set; }
    }
}
