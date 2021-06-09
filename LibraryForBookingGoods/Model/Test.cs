using System.Collections.Generic;

namespace ShopWebApi.Model
{
    public class Test
    {
        public ICollection<ReservedOrder> Order { get; set; }
        public ICollection<ProductInWarehouse> ProductInWarehouse { get; set; }
    }
}
