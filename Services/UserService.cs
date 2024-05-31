using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect.Services
{
    public class UserService : IUserService
    {
        private readonly AgriEnergyConnectDbContext _context;

        public UserService(AgriEnergyConnectDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            var user = await _context.Users
               .Where(u => u.Email == username && u.Password == password)
               .FirstOrDefaultAsync();

            return user;
        }
        public interface IUserService
        {
            Task<User> GetUserAsync(string username, string password);
        }
    }
}

     

    

