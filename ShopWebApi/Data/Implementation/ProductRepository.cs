using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System.Linq;
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

        public Product GetProductByName(string productName)
        {
            var result = _dbContext.Products.FirstOrDefault(x => x.ProductName == productName);
            return result;
        }
    }
}
