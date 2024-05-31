using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnect.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> AddProducts(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.FarmerEmail = HttpContext.User.Identity.Name;
            await _productService.AddProductAsync(product);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ViewProducts(string farmerEmail)
        {
            var products = await _productService.GetProductsAsync(farmerEmail);
            return View(products);
        }
    }
}