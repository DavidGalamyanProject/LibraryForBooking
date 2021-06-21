using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IWarehouseManager
    {
        /// <summary> Возвращает позицию товара со складе. </summary>
        StockPosition GetStockPosition(Product product);

        /// <summary> Обновляет позицию на складе. </summary>
        void UpdateStockPositionWarehouse(StockPosition productInWarehouse);

        /// <summary> Добавляет товар на склад. </summary>
        /// <return> VendorCode(Артикул) позиции на складе.</return>
        Task<Guid> CreateStockPosition(StockPositionAddRequest request);

        /// <summary> Обновляет позицию на складе. </summary>
        /// <returns> Возвращает обновленную позицию. </returns>
        StockPosition UpdateStockPositionWarehouseByVendorCode(StockPositionUpdateRequest request);

        /// <summary> Возвращает все позиции которые есть на складе. </summary>
        Task<List<StockPosition>> GetAllStockPositions();
    }
}
