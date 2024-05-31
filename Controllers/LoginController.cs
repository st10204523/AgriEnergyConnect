using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class LoginController : Controller
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        return View();
        var user = await _userService.GetUserAsync(model.Username, model.Password);
        if (user != null)
        {
            await HttpContext.SignInAsync(User);
            if (user.Role == "Farmer")
            {
                return RedirectToAction("AddProducts", "Farmer");
            }
            else if (user.Role == "Employee")
            {
                return RedirectToAction("ViewProducts", "Employee");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync("Cookies");
        return RedirectToAction("Login", "Login");
    }
}