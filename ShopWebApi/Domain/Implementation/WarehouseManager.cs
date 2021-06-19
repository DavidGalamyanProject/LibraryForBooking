using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Domain.Implementation
{
    public class WarehouseManager : IWarehouseManager
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseManager(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;            
        }

        public Warehouse GetProduct(Product product)
        {
            var result = _warehouseRepository.GetProduct(product);
            return result;
        }

        public void UpdateProductWarehouse(Warehouse productInWarehouse)
        {
            _warehouseRepository.UpdateProductWarehouse(productInWarehouse);
        }
    }
}
