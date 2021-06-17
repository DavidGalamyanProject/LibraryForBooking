using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Сущность базы данных, для таблицы Warehouse </summary>
    public class ProductReserve
    {
        public Guid IdOrder { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }        
    }
}
