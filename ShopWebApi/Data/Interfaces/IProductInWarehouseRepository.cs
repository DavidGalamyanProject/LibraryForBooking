using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IProductInWarehouseRepository
    {
        Task<ProductInWarehouse> GetProduct(ProductReservRequest request);
        void UpdateProduct(ProductInWarehouse productUpdate);
        Task<ProductInWarehouse> TryGetProduct(ProductReservRequest request);
        Task<Dictionary<string, int>> GetListProduct();
    }
}
