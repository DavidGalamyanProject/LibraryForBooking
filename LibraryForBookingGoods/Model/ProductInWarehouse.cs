using System;
using System.Collections.Generic;

namespace ShopWebApi.Model
{
    /// <summary> Сущность для базы данных, в таблице StorageWarehouse </summary>
    public class ProductInWarehouse
    {
        public Guid Article { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool ProductOutOfStock => 0 >= Quantity;
        public ICollection<Test> Collection { get; set; }
    }
}
