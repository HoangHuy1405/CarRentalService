using CarRental.Data;
using CarRental.Models;
using CarRental.Repository;
using System.Security.Claims;

namespace CarRental.Service
{
    public class DriverService {
		private readonly DriverRepository driverRepo;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public DriverService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
			driverRepo = new DriverRepository(context);
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<ServiceResult> RegisterDriver(string userID) {
            // Check if the user already has a pending driver registration
            var existingDriver = await driverRepo.GetDriverByID(userID);

            if (existingDriver != null && existingDriver.Status == DriverStatus.Pending) {
				// If the driver exists and the status is Pending, inform the user
				return ServiceResult.FailureResult("The request is already pending, please wait!");
            } else return ServiceResult.SuccessResult();
        }


        public async Task<ServiceResult> AddDriverAsync(string userId, DriverRegistrationView driverReg) {
			if (string.IsNullOrEmpty(userId)) {
				return ServiceResult.FailureResult("User ID is required.");
			}
			string licenseImageUrl = string.Empty;
			if (driverReg.LicenseImg != null) {
				licenseImageUrl = await UploadImage("images/Licenses/", driverReg.LicenseImg);
			} else return ServiceResult.FailureResult("license image not found");

			string nationalIdUrl = string.Empty;
			if (driverReg.NationalIdImg != null) {
				nationalIdUrl = await UploadImage("images/NationalID/", driverReg.NationalIdImg);
			} else return ServiceResult.FailureResult("national id image not found");

			var driver = new Driver {
				UserID = userId,
				LicenseNumber = driverReg.LicenseNumber!,
				LicenseExpiryDate = driverReg.LicenseExpiryDate!.Value,
				LicenseImageUrl = licenseImageUrl,
				NationalIdUrl = nationalIdUrl,
				Status = DriverStatus.Pending // Default to Pending status
			};
			
			await driverRepo.Add(driver);
			return ServiceResult.SuccessResult();
		}

		private async Task<string> UploadImage(string folderPath, IFormFile file) {
			// Guid.NewGuid().ToString() to generate 32-bit random to unique identify the file name 
			// incase of duplicates of same names amongus the users
			folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
			string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
			await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
			return "/" + folderPath;
		}



    }
}
