using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Model
{
    /// <summary> Сущность для базы данных, в таблице ReservedOrders </summary>
    public class ReservedOrder
    {
        public Guid IdOrder { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }
        public ICollection<Test> Collection { get; set; }
    }
}
