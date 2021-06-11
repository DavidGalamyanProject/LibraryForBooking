using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IStorageWarehouseRepository
    {
        Task<ProductInWarehouse> GetProduct(ProductReservRequest request);
        void UpdateProduct(ProductInWarehouse productUpdate);
        Task<ProductInWarehouse> TryGetProduct(ProductReservRequest request);
    }
}
