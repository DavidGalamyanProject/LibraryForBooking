using ShopWebApi.Model.Entity;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IProductManager
    {
        /// <summary> Возвращает продукт по имени </summary>
        Product GetProductByName(string productName);
    }
}
