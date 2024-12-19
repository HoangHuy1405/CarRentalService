using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers {
    public class ShareDriveController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
