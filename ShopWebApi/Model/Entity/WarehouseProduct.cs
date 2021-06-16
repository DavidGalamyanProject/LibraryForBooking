using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Сущность базы данных, для таблицы Warehouse </summary>
    public class WarehouseProduct
    {
        public Guid Article { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string ProductInformation { get; set; }

    }
}
