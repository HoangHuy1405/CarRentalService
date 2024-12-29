using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.ShareDrive {
    public class PassengerRide {
        [Key]
        public int PassengerRideID { get; set; }

        [Required]
        [ForeignKey(nameof(Passenger))] // Defines it as a foreign key to ApplicationUser
        public string PassengerID { get; set; }
        [ValidateNever]
        public ApplicationUser? Passenger { get; set; }

        [ForeignKey(nameof(DriverRide))]
        public int DriverRideID { get; set; }
        [ValidateNever]
        public DriverRide DriverRide { get; set; }

        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Seats { get; set; }
        public TimeOnly? DepartTime { get; set; }
        public DateTime? DepartDate { get; set; }

        public float TotalFee { get; set; }
        public float DepositFee { get; set; }

        public Status Status { get; set; } = Status.Pending;

        public override string ToString() {
            return $"PassengerRideID: {PassengerRideID}, " +
                   $"PassengerID: {PassengerID}, " +
                   $"Passenger: {(Passenger != null ? Passenger.UserName : "N/A")}, " +
                   $"DriverRideID: {DriverRideID}, " +
                   $"DriverRide: {(DriverRide != null ? DriverRide.Driver?.User?.UserName : "N/A")}, " +
                   $"StartLocation: {StartLocation}, " +
                   $"EndLocation: {EndLocation}, " +
                   $"Seats: {Seats}, " +
                   $"DepartTime: {(DepartTime.HasValue ? DepartTime.Value.ToString("hh\\:mm") : "N/A")}, " +
                   $"DepartDate: {(DepartDate.HasValue ? DepartDate.Value.ToString("yyyy-MM-dd") : "N/A")}, " +
                   $"TotalFee: {TotalFee}, " +
                   $"DepositFee: {DepositFee}, " +
                   $"Status: {Status}";
        }

    }
}
