using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity склада </summary>
    public class Warehouse
    {
        /// <summary> Артикул позиции на складе </summary>
        public Guid Article { get; set; }

        /// <summary> Продукт на складе </summary>
        public Product Product { get; set; }

        /// <summary> Колличество на складе </summary>
        public int Quantity { get; set; }
    }
}
