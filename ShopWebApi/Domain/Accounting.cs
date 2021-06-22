﻿using ShopWebApi.Model.Dto;
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
            set
			{								
			}
        }
    }
}
