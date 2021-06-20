using ShopWebApi.Model.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ShopWebApi.Domain
{
    /// <summary> Списки учета, с их помощью снимается нагрузка с БД </summary>
    internal class Accounting
    {

        private static readonly object _lock = new object();
        private static readonly object _lock2 = new object();
        private static ConcurrentQueue<ReservRequestToQueue> _reservRequestToQueues;
        private static ConcurrentDictionary<Guid, string> _reservs;
        private Accounting() { }
        /// <summary> Реализация многопоточного Singlton </summary>
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
            set { }
        }
        /// <summary> Реализация многопоточного Singlton </summary>
        internal static ConcurrentDictionary<Guid,string> ListOfReservedProducts {
            get 
            {
                if (_reservs == null)
                {
                    lock (_lock2)
                    {
                        if (_reservs == null)
                        {
                            _reservs = new ConcurrentDictionary<Guid, string>();
                        }
                    }
                }
                return _reservs;
            }
            set { }
        }

        /// <summary> Достаем из RequestReservQueue очереди все запросы (конвертируя в лист для чтения), после чего очищаем нашу очередь. </summary>
        public static ImmutableList<ReservRequestToQueue> GetImmutableList()
        {
            lock(_lock)
            {
                var listRequest = Accounting.RequestReservQueue.ToImmutableList();
                Accounting.RequestReservQueue.Clear();
                return listRequest;
            }
        }
    }
}
