using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Implementation
{
    public class ProductInWarehouseRepository : IProductInWarehouseRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductInWarehouseRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, int>> GetListProduct()
        {
            var result = await _dbContext.StorageWarehouse.ToDictionaryAsync(x => x.ProductName, x => x.Quantity);
            return result;
        }

        public Task<ProductInWarehouse> GetProduct(ProductReservRequest request)
        {
            var result = _dbContext.StorageWarehouse.FirstOrDefaultAsync(x =>
                                                   x.ProductName == request.ProductName);
            return result;
        }
        /// <summary>Если товара достаточно на складе, тогда его значение в Бд обновится и вернет продукт, уже с измененным количеством </summary>
        public async Task<ProductInWarehouse> TryGetProduct(ProductReservRequest request)
        {
            var result = await _dbContext.StorageWarehouse.FirstOrDefaultAsync(x => x.ProductName == request.ProductName && 
                                                                        (x.Quantity - request.Quantity) >= 0);
            if(result == null)
            {
                return default;
            }
            result.Quantity -= request.Quantity;
            _dbContext.StorageWarehouse.Update(result);
            return result;
        }

        public void UpdateProduct(ProductInWarehouse productUpdate)
        {
            _dbContext.StorageWarehouse.Update(productUpdate);
        }
    }
}
