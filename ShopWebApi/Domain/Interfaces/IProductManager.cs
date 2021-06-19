using ShopWebApi.Model.Entity;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IProductManager
    {
        Product GetProductByName(string productName);
    }
}
