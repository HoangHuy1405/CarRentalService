using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.ShareDrive {
    public class PassengerRideView {
        [Required]
        [Display(Name = "Starting location")]
        public string StartLocation { get; set; }
        [Required]
        [Display(Name = "Ending location")]
        public string EndLocation { get; set; }
        [Required]
        [Display(Name = "Number of seats available")]
        public int Seats { get; set; }
        [Required]
        [Display(Name = "Departure time")]
        public TimeOnly? DepartTime { get; set; }
        [Required]
        [Display(Name = "Departure date")]
        public DateTime? DepartDate { get; set; }
    }
}
