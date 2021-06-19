using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Сущность базы данных, для таблицы Warehouse </summary>
    public class Reserv
    {
        public Guid IdOrder { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }        
    }
}
