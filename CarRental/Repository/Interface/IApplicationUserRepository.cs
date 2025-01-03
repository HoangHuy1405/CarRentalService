using CarRental.Models;

namespace CarRental.Repository.Interface
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task AddMoneyToBalance(string userId, float amount);
        Task SubtractMoneyFromBalance(string userId, float amount);
    }
}
