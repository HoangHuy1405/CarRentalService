using CarRental.Models.DTO;

namespace CarRental.Models.ShareDrive {
    public class ChooseDriverView {
        public IEnumerable<DriverRideDto> DriverRides { get; set; }
        public PassengerRideView passenger { get; set; }
    }
}
