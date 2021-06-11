using System;

namespace ShopWebApi.Model
{
    /// <summary> Сущность для базы данных, в таблице ReservedOrders </summary>
    public class ReservedProducts
    {
        public Guid IdOrder { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }
        
    }
}
