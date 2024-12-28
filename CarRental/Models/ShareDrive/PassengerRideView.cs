using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.ShareDrive {
    public class PassengerRideView {
        [Required]
        [Display(Name = "Starting location*")]
        public string StartLocation { get; set; }
        [Required]
        [Display(Name = "Ending location*")]
        public string EndLocation { get; set; }
        [Required]
        [Display(Name = "Number of seats needed")]
        public int Seats { get; set; }

        [Display(Name = "Time to go")]
        public TimeOnly? DepartTime { get; set; }
        [Display(Name = "Date to go")]
        public DateTime? DepartDate { get; set; }
    }
}
