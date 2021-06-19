using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Сущность базы данных, для таблицы Warehouse </summary>
    public class Warehouse
    {
        public Guid Article { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
