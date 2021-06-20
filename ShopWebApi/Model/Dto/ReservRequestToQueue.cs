using System;

namespace ShopWebApi.Model.Dto
{
    /// <summary> Временая модель для резерва </summary>
    public class ReservRequestToQueue
    {
        /// <summary> Ид резерва (заказа) </summary>
        public Guid IdOrder { get; set; }

        /// <summary> Название продукта </summary>
        public string ProductName { get; set; }

        /// <summary> Колличество продукта </summary>
        public int Quantity { get; set; }

        /// <summary> Время когда поступил запрос на резерв </summary>
        public DateTime ReservationTime { get; set; }

    }
}
