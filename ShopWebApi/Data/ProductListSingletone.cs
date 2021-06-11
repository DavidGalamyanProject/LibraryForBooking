using ShopWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Data
{
    internal class ProductListSingletone
    {
        internal static List<ProductInWarehouse> Accounting { get; set; }
    }
}
