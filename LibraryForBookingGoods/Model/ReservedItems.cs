using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryForBookingGoods.Model
{
    public class ReservedItems
    {
        public Guid IdOrder { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
