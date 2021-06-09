using System;

namespace LibraryForBookingGoods.Model
{
    public class StorageWarehouse
    {
        public Guid Article { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
