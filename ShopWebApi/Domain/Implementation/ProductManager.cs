using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Domain.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductByName(string productName)
        {
            var result = _productRepository.GetProductByName(productName);
            return result;
        }
    }
}
