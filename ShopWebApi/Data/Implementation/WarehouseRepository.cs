using Microsoft.EntityFrameworkCore;
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

		public StockPosition GetStockPositionByProduct(Product product)
		{
			var result = _dbContext.Warehouse.FirstOrDefault(x => x.Product == product);
			return result;
		}

		public async Task<StockPosition> GetStockPositionByGuid(Guid id)
        {
            var result = await _dbContext.Warehouse.FindAsync(id);
            return result;
        }
		public void UpdateProductWarehouse(StockPosition productInWarhouse)
		{
			_dbContext.Warehouse.Update(productInWarhouse);
			_dbContext.SaveChanges();
		}
	}
}
