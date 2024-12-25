namespace CarRental.Service {
    public class ServiceResult {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public static ServiceResult SuccessResult() {
            return new ServiceResult { Success = true };
        }

        public static ServiceResult FailureResult(List<string> errors) {
            return new ServiceResult { Success = false, Errors = errors };
        }

        public static ServiceResult FailureResult(string error) {
            return new ServiceResult { Success = false, Errors = new List<string> { error } };
        }
    }
}
