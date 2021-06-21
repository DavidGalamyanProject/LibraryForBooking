using System;
using System.Collections.Generic;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity товара. </summary>
    public class Product
    {
        /// <summary> Первичный ключ. </summary>
        public Guid Id { get; set; }

        /// <summary> Название продукта. </summary>
        public string ProductName { get; set; }

        /// <summary> Информация о продукте. </summary>
        public string ProductInformation { get; set; }


        public ICollection<Reserv> Reserve { get; set; }
        public ICollection<StockPosition> Warehouse { get; set; }
    }
}
