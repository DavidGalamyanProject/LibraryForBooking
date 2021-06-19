using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System.Linq;

namespace ShopWebApi.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _dbContext;
        public ProductRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product GetProductByName(string productName)
        {
            var result = _dbContext.Products.FirstOrDefault(x => x.ProductName == productName);
            return result;
        }
    }
}
