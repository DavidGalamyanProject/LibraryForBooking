using ShopWebApi.Data;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class ProductInWarehouseManager : IProductInWarehouseManager
    {
        private readonly IProductInWarehouseRepository _productRepository;

        public ProductInWarehouseManager(IProductInWarehouseRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task UploadProductList()
        {
            Accounting.ProductList = await _productRepository.GetListProduct();            
        }
    }
}
