using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualStudio.TextTemplating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models.ShareDrive
{
    public class DriverRide
    {
        [Key]
        public int DriverRideID { get; set; }

        [ForeignKey(nameof(Driver))] 
        public string DriverID { get; set; }
        [ValidateNever]
        public Driver? Driver { get; set; }

        [ValidateNever]
        public ICollection<PassengerRide> PassengerRides { get; set; } // One-to-Many relationship with PassengerRide


        [Required]
        [Display(Name = "Starting location*")]
        public string StartLocation { get; set; }
        [Required]
        [Display(Name = "Ending location*")]
        public string EndLocation { get; set; }
        [Required]
        [Display(Name = "Number of seats available*")]
        public int Seats { get; set; }
        [Required]
        [Display(Name = "Departure time*")]
        public TimeOnly? DepartTime { get; set; }
        [Required]
        [Display(Name = "Departure date*")]
        public DateTime? DepartDate { get; set; } 

        public int SeatLeft { get; set; }
        public Status Status { get; set; } = Status.Pending;

        public DriverRide() {
            SeatLeft = Seats;
        }

    }
}
