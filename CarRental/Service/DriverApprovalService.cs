using CarRental.Data;
using CarRental.Models;
using CarRental.Repository;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Service {
    public class DriverApprovalService {
        private readonly DriverRepository driverRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public DriverApprovalService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            driverRepo = new DriverRepository(context);
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IEnumerable<Driver>> getAllPending() {
            return await driverRepo.getAllPending();
        }

        public async Task<ServiceResult> ApproveDriverAsync(string id)
        {
            Driver? driver = await driverRepo.GetDriverByID(id);
            if (driver == null) return ServiceResult.FailureResult("Driver not found.");
            driver.Status = DriverStatus.Approved;
            await driverRepo.Update(driver);
            // Get the user associated with the driver
            var user = await userManager.FindByIdAsync(driver.UserID!);
            if (user == null) return ServiceResult.FailureResult("User not found.");
            // Check if the user is already in the "Driver" role
            if (!await userManager.IsInRoleAsync(user, "Driver"))
            {
                // Add the user to the "Driver" role
                var addRoleResult = await userManager.AddToRoleAsync(user, "Driver");
                if (!addRoleResult.Succeeded)
                {
                    return ServiceResult.FailureResult("Failed to assign 'Driver' role.");
                }
            }
            //await userManager.UpdateSecurityStampAsync(user);

            return ServiceResult.SuccessResult();
        }
        public async Task<ServiceResult> RejectDriverAsync(string id) {
            Driver driver = await driverRepo.GetDriverByID(id);
            if (driver == null) return ServiceResult.FailureResult("Driver not found.");
            driver.Status = DriverStatus.Rejected;
            await driverRepo.Update(driver);
            return ServiceResult.SuccessResult();
        }
        
    }
}
