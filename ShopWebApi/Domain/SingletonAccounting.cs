using ShopWebApi.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ShopWebApi.Domain
{
    /// <summary> Списки учета, с их помощью снимается нагрузка с БД </summary>
    internal class SingletonAccounting
    {

        private static readonly object _lock = new object();
        private static ConcurrentQueue<ReservRequestToQueue> _reservRequestToQueues;
        private SingletonAccounting() { }
        internal static ConcurrentQueue<ReservRequestToQueue> RequestReservQueue {
            get
            {
                if (_reservRequestToQueues == null)
                {
                    lock (_lock)
                    {
                        if (_reservRequestToQueues == null)
                        {
                            _reservRequestToQueues = new ConcurrentQueue<ReservRequestToQueue>();
                        }
                    }
                }
                return _reservRequestToQueues;
            }
            set
            {
                if (_reservRequestToQueues == null)
                {
                    lock (_lock)
                    {                       
                        if (_reservRequestToQueues == null)
                        {
                            _reservRequestToQueues = new ConcurrentQueue<ReservRequestToQueue>();
                        }
                    }
                }
            }
        }
        internal static ImmutableDictionary<Guid,Guid> ListOfReservedProducts { get; set; }
    }
}
