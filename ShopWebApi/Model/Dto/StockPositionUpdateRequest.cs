using System;

namespace ShopWebApi.Model.Dto
{
    /// <summary> Запрос на изменение позиции на складе </summary>
    public class StockPositionUpdateRequest
    {
        /// <summary> Ид позиции </summary>
        public Guid VendorCode { get; set; }

        /// <summary> Колличество продукта </summary>
        public int Quantity { get; set; }
    }
}
