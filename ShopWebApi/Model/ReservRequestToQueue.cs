using System;

namespace ShopWebApi.Model
{
    public class ReservRequestToQueue
    {
        public Guid IdOrder { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }

    }
}
