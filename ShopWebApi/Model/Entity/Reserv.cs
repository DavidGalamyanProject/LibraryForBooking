using System;

namespace ShopWebApi.Model.Entity
{
    /// <summary> Entity резерва </summary>
    public class Reserv
    {
        /// <summary> Ид резерва (ид заказа) </summary>
        public Guid IdOrder { get; set; }

        /// <summary> Ид зарезервированного товара </summary>
        public Guid ProductId { get; set; }

        /// <summary> Колличество зарезервированного товара </summary>
        public int Quantity { get; set; }

        /// <summary> Время резерва </summary>
        public DateTime ReservationTime { get; set; }

        /// <summary> Ссылка на товар </summary>
        public Product Product { get; set; }
    }
}
