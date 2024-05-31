using AgriEnergyConnect.Models;

public interface IProductService
{
    Task<Product> AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync(string farmerEmail);
}
