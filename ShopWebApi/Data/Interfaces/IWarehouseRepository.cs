using ShopWebApi.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IWarehouseRepository
    {
        /// <summary> Возвращает товар из базы данных, если товара нет вернется null  </summary>
        Warehouse GetProduct(Product product);
        /// <summary> Изменяет количество товара на складе </summary>
        /// <param name="productName"></param>
        /// <param name="quantity"></param>
        void UpdateProductWarehouse(Warehouse productInWarehouse);
        /// <summary> Метод возвращает Dictionary<productName,quantity> товаров которые есть на складе и их количество </summary>
        Task<List<Warehouse>> GetListProduct();
    }
}
