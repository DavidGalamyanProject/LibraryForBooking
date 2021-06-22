using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IWarehouseRepository
    {
		/// <summary> Возвращает позицию склада из базы данных, если позиции нет, вернется null.  </summary>
		Task<StockPosition> GetStockPositionByProduct(Product product);

		/// <summary> Изменяет количество товара на складе. </summary>
		Task UpdateProductWarehouse(StockPosition productInWarehouse);

        /// <summary> Метод, возвращает товары которые есть на складе и их количество. </summary>
        Task<List<StockPosition>> GetAllStockPositions();

        /// <summary> Добавляет позицию товара на склад. </summary>
        Task AddStockPosition(StockPosition stockPosition);
		/// <summary> Ищет товар по Ид. </summary>
		Task<StockPosition> GetStockPositionByGuid(Guid id);
    }
}
