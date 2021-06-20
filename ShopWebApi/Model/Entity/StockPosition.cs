using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity позиции на складе </summary>
    public class StockPosition
    {
        /// <summary> VendorCode(id) позиции на складе </summary>
        public Guid VendorCode { get; set; }

        /// <summary> Продукт на складе </summary>
        public Product Product { get; set; }

        /// <summary> Колличество на складе </summary>
        public int Quantity { get; set; }
    }
}
