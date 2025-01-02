using CarRental.Models.ShareDrive;

namespace CarRental.Models.ModelView {
    public class TicketView {
        public Ticket PDFTicket { get; set; }
        public Ticket QRCodeTicket { get; set; }
    }
}
