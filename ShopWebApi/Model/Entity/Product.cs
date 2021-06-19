using System;
using System.Collections.Generic;

namespace ShopWebApi.Model.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductInformation { get; set; }
        public ICollection<Reserv> Reserve { get; set; }
        public ICollection<Warehouse> Warehouse { get; set; }
    }
}
