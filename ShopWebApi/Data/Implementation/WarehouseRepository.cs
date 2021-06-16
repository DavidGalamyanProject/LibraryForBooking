using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ShopDbContext _dbContext;

        public WarehouseRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, int>> GetListProduct()
        {
            var result = await _dbContext.Warehouse.ToDictionaryAsync(x => x.ProductName, x => x.Quantity);
            return result;
        }

        public async Task<WarehouseProduct> GetProduct(string productName)
        {
            var result = await _dbContext.Warehouse.FirstOrDefaultAsync(x => x.ProductName == productName);
            return result;
        }
        public void UpdateWarehouse(string productName, int quantity)
        {
             var productInWarehouse =  GetProduct(productName).Result;
             productInWarehouse.Quantity = quantity;
             _dbContext.Warehouse.Update(productInWarehouse);
             _dbContext.SaveChanges();           
        }
    }
}
