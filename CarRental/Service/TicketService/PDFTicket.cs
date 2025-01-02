using CarRental.Models.ShareDrive;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CarRental.Service.TicketService {
    public class PDFTicket : ITicketStrategy {
        public async Task<Ticket> CreateTicket(PassengerRide passengerRide) {
            Ticket ticket = new Ticket {
                TicketID = Guid.NewGuid().ToString(),
                PassengerName = passengerRide.Passenger.UserName,
                DriverName = passengerRide.DriverRide.Driver.User.UserName,
                StartLocation = passengerRide.StartLocation,
                EndLocation = passengerRide.EndLocation,
                DepartureDate = passengerRide.DepartDate,
                DepartureTime = passengerRide.DepartTime,
                Seats = passengerRide.Seats,
                TotalFee = passengerRide.TotalFee,
                DepositFee = passengerRide.DepositFee,
                TicketDetails = $"Ticket for {passengerRide.Passenger.UserName} from {passengerRide.StartLocation} to {passengerRide.EndLocation}.",
                PassengerRideID = passengerRide.PassengerRideID,
                PassengerID = passengerRide.PassengerID
            };
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "tickets");
            string filePath = Path.Combine(directoryPath, $"{ticket.TicketID}.pdf");
            if (!Directory.Exists(directoryPath)) {
                Directory.CreateDirectory(directoryPath);
            }
            GeneratePDF(ticket, filePath);
            ticket.pdfPath = $"/tickets/{ticket.TicketID}.pdf";
            return ticket;
        }
        public void GeneratePDF(Ticket ticket, string filePath) {
            Console.WriteLine("Generating PDF file .....................");
            using (PdfDocument document = new PdfDocument()) {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Define fonts
                XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                XFont headerFont = new XFont("Arial", 14, XFontStyleEx.Bold);
                XFont contentFont = new XFont("Arial", 12, XFontStyleEx.Regular);

                // Define layout dimensions
                int margin = 40;
                int columnWidth = 200;
                int rowHeight = 20;

                // Draw the title
                gfx.DrawString("CAPY - Ticket Confirmation", titleFont, XBrushes.Black, new XRect(0, margin, page.Width, rowHeight), XStringFormats.TopCenter);

                // Draw the generated date
                string generatedDate = $"Generated On: {DateTime.Now}";
                gfx.DrawString(generatedDate, contentFont, XBrushes.Black, new XRect(0, margin + rowHeight, page.Width, rowHeight), XStringFormats.TopCenter);

                // Draw a horizontal line below the title
                gfx.DrawLine(XPens.Black, margin, margin + 2 * rowHeight, page.Width - margin, margin + 2 * rowHeight);

                // Draw the Ticket ID in one row
                gfx.DrawString($"Ticket ID: {ticket.TicketID}", headerFont, XBrushes.Black, new XRect(0, margin + 3 * rowHeight, page.Width, rowHeight), XStringFormats.TopCenter);

                // Draw another horizontal line below the Ticket ID
                gfx.DrawLine(XPens.Black, margin, margin + 4 * rowHeight, page.Width - margin, margin + 4 * rowHeight);

                // Start left column
                int leftColumnX = margin;
                int leftColumnY = margin + 5 * rowHeight;

                gfx.DrawString("Passenger:", headerFont, XBrushes.Black, leftColumnX, leftColumnY);
                gfx.DrawString(ticket.PassengerName, contentFont, XBrushes.Black, leftColumnX, leftColumnY + rowHeight);

                gfx.DrawString("Driver:", headerFont, XBrushes.Black, leftColumnX, leftColumnY + 2 * rowHeight);
                gfx.DrawString(ticket.DriverName, contentFont, XBrushes.Black, leftColumnX, leftColumnY + 3 * rowHeight);

                gfx.DrawString("Seats:", headerFont, XBrushes.Black, leftColumnX, leftColumnY + 4 * rowHeight);
                gfx.DrawString(ticket.Seats.ToString(), contentFont, XBrushes.Black, leftColumnX, leftColumnY + 5 * rowHeight);

                // Start right column
                int rightColumnX = leftColumnX + columnWidth;
                int rightColumnY = leftColumnY;

                gfx.DrawString("Start Location:", headerFont, XBrushes.Black, rightColumnX, rightColumnY);
                gfx.DrawString(ticket.StartLocation, contentFont, XBrushes.Black, rightColumnX, rightColumnY + rowHeight);

                gfx.DrawString("End Location:", headerFont, XBrushes.Black, rightColumnX, rightColumnY + 2 * rowHeight);
                gfx.DrawString(ticket.EndLocation, contentFont, XBrushes.Black, rightColumnX, rightColumnY + 3 * rowHeight);

                gfx.DrawString("Departure Date:", headerFont, XBrushes.Black, rightColumnX, rightColumnY + 4 * rowHeight);
                gfx.DrawString(ticket.DepartureDate.HasValue ? ticket.DepartureDate.Value.ToString("yyyy-MM-dd") : "N/A", contentFont, XBrushes.Black, rightColumnX, rightColumnY + 5 * rowHeight);

                gfx.DrawString("Total Fee:", headerFont, XBrushes.Black, rightColumnX, rightColumnY + 6 * rowHeight);
                gfx.DrawString(ticket.TotalFee.ToString("C"), contentFont, XBrushes.Black, rightColumnX, rightColumnY + 7 * rowHeight);

                // Save the document
                document.Save(filePath);
            }
        }


    }


}
