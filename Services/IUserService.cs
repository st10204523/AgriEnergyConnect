using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;

public interface IUserService
{
    Task<User> GetUserAsync(string username, string password);
}
