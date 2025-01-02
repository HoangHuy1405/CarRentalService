using CarRental.Data;
using CarRental.Models;
using CarRental.Models.ShareDrive;
using CarRental.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Controllers {
    public class HistoryController : Controller {
        private readonly RentalRepository _RentalRepo;
        private readonly TicketRepository _TicketRepository;
        public HistoryController(ApplicationDbContext context) {
            _RentalRepo = new RentalRepository(context);
            _TicketRepository = new TicketRepository(context);
        }
        public async Task<IActionResult> Rental() {
            string UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Rental> Rentals = await _RentalRepo.GetAllFromID(UserID);
            return View(Rentals);
        }
        public async Task<IActionResult> ShareDrive() {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) {
                Console.WriteLine("userID = null");
                // Redirect to login or handle the error appropriately
                return RedirectToAction("Login", "Account");
            }
            IEnumerable<Ticket> tickets = await _TicketRepository.GetAllTicketsByUserID(userId);
            return View(tickets);
        }


    }
}
