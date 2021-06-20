using ShopWebApi.Model.Entity;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IWarehouseManager
    {
        /// <summary> Возвращает позицию товара со складе </summary>
        Warehouse GetProduct(Product product);
        /// <summary> Обновляет позицию на складе </summary>
        void UpdateProductWarehouse(Warehouse productInWarehouse);
    }
}
