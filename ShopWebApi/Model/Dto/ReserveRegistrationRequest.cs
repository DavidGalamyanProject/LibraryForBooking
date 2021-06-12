using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Model.Dto
{
    public class ReserveRegistrationRequest
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeReserv { get; set; }
    }
}
