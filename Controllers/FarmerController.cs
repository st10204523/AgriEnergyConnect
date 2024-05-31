using Microsoft.AspNetCore.Mvc;


namespace AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly ProductService _productService;

        public FarmerController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> AddProducts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(Product product)
        {
            await _productService.AddProductAsync(product);
            return RedirectToAction("AddProducts");
        }

        public async Task<IActionResult> ViewProducts()
        {
            var user = await HttpContext.GetUserAsync();
            var products = await _productService.GetProductsByFarmerAsync(user.Email);
            return View(products);
        }
    }
}
