using ShopWebApi.Model.Entity;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IProductRepository
    {
        /// <summary> Ищет товар по имени </summary>
        Product GetProductByName(string productName);

        /// <summary> Добавляет товар </summary>
        Task AddProduct(Product product);
    }
}
