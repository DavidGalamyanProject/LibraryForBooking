using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    internal interface IReservedOrderManager
    {
        Task<OrderResponse> MakeAReservationProduct();
    }
}
