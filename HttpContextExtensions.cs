namespace AgriEnergyConnect
{
   

    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AgriEnergyConnect.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    public static class HttpContextExtensions
    {
        public static async Task<User> GetUserAsync(this HttpContext httpContext)
        {
            var userManager = httpContext.RequestServices.GetService<UserManager<User>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            return user;
        }

        public static async Task<string> GetUserEmailAsync(this HttpContext httpContext)
        {
            var user = httpContext.User;
            var emailClaim = user.FindFirstValue(ClaimTypes.Email);
            return emailClaim;
        }
    }
}
