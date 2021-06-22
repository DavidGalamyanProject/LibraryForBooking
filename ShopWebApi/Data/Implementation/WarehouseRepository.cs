using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
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

        public async Task AddStockPosition(StockPosition stockPosition)
        {
            await _dbContext.Warehouse.AddAsync(stockPosition);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<StockPosition>> GetAllStockPositions()
        {
            var result = await _dbContext.Warehouse.ToListAsync();
            return result;
        }

        public async Task<StockPosition> GetStockPositionByProduct(Product product)
        {
            var result = await _dbContext.Warehouse.FirstOrDefaultAsync(x => x.Product == product);
            return result;
        }

        public async Task<StockPosition> GetStockPositionByGuid(Guid id)
        {
            var result = await _dbContext.Warehouse.FindAsync(id);
            return result;
        }

        public async Task UpdateProductWarehouse(StockPosition productInWarhouse)
        {
            _dbContext.Warehouse.Update(productInWarhouse);
            await _dbContext.SaveChangesAsync();
        }
    }
}
