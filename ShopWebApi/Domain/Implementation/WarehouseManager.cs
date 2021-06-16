using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class WarehouseManager : IWarehouseManager
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseManager(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task UploadProductList()
        {
            var firstDictionary = await _warehouseRepository.GetListProduct();
            SingletonAccounting.ProductsWarehouse = new ConcurrentDictionary<string, int>(firstDictionary);
        }
        public void UpdateProductWarehouse(ImmutableDictionary<string,int> productWarehouse)
        {
            foreach(var product in productWarehouse)
            {
               _warehouseRepository.UpdateWarehouse(product.Key, product.Value);
            }
        }
    }
}
