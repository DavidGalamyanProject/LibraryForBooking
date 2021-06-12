using ShopWebApi.Model;
using System.Collections.Generic;

namespace ShopWebApi.Data
{
    internal struct Accounting
    {
        internal static Dictionary<string,int> ProductList { get; set; }
        internal static List<ReservedProducts> ReservList { get; set; }
    }
}
