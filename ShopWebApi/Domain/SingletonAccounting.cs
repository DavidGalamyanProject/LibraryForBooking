﻿using ShopWebApi.Model.Entity;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ShopWebApi.Domain
{
    /// <summary> Списки учета, с их помощью снимается нагрузка с БД </summary>
    internal class SingletonAccounting
    {
        private SingletonAccounting() { }
        internal static ConcurrentDictionary<string, int> ProductsWarehouse { get; set; }
        internal static ConcurrentQueue<ProductReserve> RequestReservQueue { get; set; }
        internal static ImmutableList<ProductReserve> ReservList { get; set; }
    }
}