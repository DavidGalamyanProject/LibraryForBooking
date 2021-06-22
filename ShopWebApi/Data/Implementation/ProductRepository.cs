using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Implementation
{
	public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _dbContext;
        public ProductRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByName(string productName)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductName == productName);
            return result;
        }
    }
}
