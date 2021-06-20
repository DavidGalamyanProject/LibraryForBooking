using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity резерва </summary>
    public class Reserv
    {
        /// <summary> Ид резерва (ид заказа) </summary>
        public Guid IdOrder { get; set; }
        /// <summary> Зарезервированный продукт </summary>
        public Product Product { get; set; }
        /// <summary> Колличество зарезервированного продукта </summary>
        public int Quantity { get; set; }
        /// <summary> Время резерва </summary>
        public DateTime ReservationTime { get; set; }        
    }
}
