using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity позиции на складе. </summary>
    public class StockPosition
    {
        /// <summary> VendorCode(id) позиции на складе. </summary>
        public Guid VendorCode { get; set; }

        /// <summary> Ид товара. </summary>
        public Guid ProductId { get; set; }

        /// <summary> Колличество на складе. </summary>
        public int Quantity { get; set; }

        /// <summary> Ссылка на товар. </summary>
        public Product Product { get; set; }
    }
}
