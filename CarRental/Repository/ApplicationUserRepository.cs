using CarRental.Data;
using CarRental.Models;
using CarRental.Repository.Interface;

namespace CarRental.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            return user ?? throw new Exception("User not found");
        }

        public async Task AddMoneyToBalance(string userId, float amount)
        {
            var user = await context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Balance += amount;
                await context.SaveChangesAsync();
            }
        }

        public async Task SubtractMoneyFromBalance(string userId, float amount)
        {
            var user = await context.Users.FindAsync(userId);
            if (user != null)
            {
                if (user.Balance < amount)
                {
                    throw new Exception("Insufficient balance");
                }
                user.Balance -= amount;
                await context.SaveChangesAsync();
            }
        }
    }
}
