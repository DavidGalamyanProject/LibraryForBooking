using ShopWebApi.Model.Entity;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IWarehouseRepository
    {
        /// <summary> Возвращает товар из базы данных, если товара нет вернется null  </summary>
        Task<WarehouseProduct> GetProduct(string productName);
        /// <summary> Изменяет количество товара на складе </summary>
        /// <param name="productName"></param>
        /// <param name="quantity"></param>
        void UpdateWarehouse(string productName, int quantity);
        /// <summary> Метод возвращает Dictionary<productName,quantity> товаров которые есть на складе и их количество </summary>
        Task<Dictionary<string, int>> GetListProduct();
    }
}
