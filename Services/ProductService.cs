using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;

public class ProductService
{
    private readonly AgriEnergyConnectDbContext _dbContext;

    public ProductService(AgriEnergyConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProductAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByFarmerAsync(string farmerEmail)
    {
        return await _dbContext.Products.Where(p => p.FarmerEmail == farmerEmail).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }
}