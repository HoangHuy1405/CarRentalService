using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models.ShareDrive
{
    public class DriverRide
    {
        [Key]
        public int DriverRideID { get; set; }

        [ForeignKey(nameof(User))] // Defines it as a foreign key to ApplicationUser
        public string UserID { get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }

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
