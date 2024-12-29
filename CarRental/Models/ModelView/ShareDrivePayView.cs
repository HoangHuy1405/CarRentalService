using CarRental.Models.ShareDrive;

namespace CarRental.Models.ModelView {
    public class ShareDrivePayView {
        public PassengerRideView? Passenger { get; set; }
        public DriverRide? DriverRide { get; set; }
    }
}
