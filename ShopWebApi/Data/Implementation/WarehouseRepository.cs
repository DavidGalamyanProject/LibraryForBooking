using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
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

        public Task<List<Warehouse>> GetListProduct()
        {
            throw new NotImplementedException();
        }

        public Warehouse GetProduct(Product product)
        {
            var result = _dbContext.Warehouse.FirstOrDefault(x => x.Product == product);
            return result;
        }

        public void UpdateProductWarehouse(Warehouse productInWarhouse)
        {
            _dbContext.Warehouse.Update(productInWarhouse);
        }
    }
}
