using ShopWebApi.Model.Dto;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IStorageWarehouseRepository
    {
        Task AddProductToBase(ProductAddRequest request);
        Task GetProduct(ProductCheckRequest request);
        Task GetAllProduct();
    }
}
