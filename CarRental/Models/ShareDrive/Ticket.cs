using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
namespace CarRental.Models.ShareDrive {
    public class Ticket {
        public string TicketID { get; set; } // Unique ID for the ticket
        public string PassengerName { get; set; }
        public string DriverName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeOnly? DepartureTime { get; set; }
		public int Seats { get; set; }
        public float TotalFee { get; set; }
        public float DepositFee { get; set; }
        public string TicketDetails { get; set; } // Additional information, like shared ride info
        public string? QRCode { get; set; } // For QR Code Generation
        public string? pdfPath { get; set; }

        // Database-only properties
        [JsonIgnore] 
        public int PassengerRideID { get; set; }
        public PassengerRide PassengerRide { get; set; }
        [JsonIgnore]
        public string PassengerID { get; set; }
    }
}


