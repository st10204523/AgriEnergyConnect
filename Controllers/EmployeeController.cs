using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Services;

namespace AgriEnergyConnect.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
            }

            return View(farmer);
        }
    }
}

