using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> CreateProduct(ProductRequest request)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductInformation = request.ProductInformation,
                ProductName = request.ProductName
            };

            await _productRepository.AddProduct(product);
            return product.Id;
        }

        public Product GetProductByName(string productName)
        {
            var result = _productRepository.GetProductByName(productName);
            return result;
        }
    }
}
