using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductByName(string productName);
    }
}
