using ShopWebApi.Model.Dto;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ShopWebApi.Domain
{
	/// <summary> Списки учета, с их помощью снимается нагрузка с БД </summary>
	internal class Accounting
	{

		private static readonly object _lock = new object();
		private static ConcurrentQueue<ReservRequestToQueue> _reservRequestToQueues;
		private Accounting() { }
		/// <summary> Реализация многопоточного Singlton </summary>
		public static void Add(ReservRequestToQueue item)
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
			lock (_lock)
			{
				_reservRequestToQueues.Enqueue(item);
			}
		}
		/// <summary> Простите я даун, не как сделать лучше! </summary>
		public static ImmutableList<ReservRequestToQueue> GetAllReservs()
		{
			lock(_lock)
			{
				var result = _reservRequestToQueues.ToImmutableList();
				_reservRequestToQueues.Clear();
				return result;
			}
		}
	}
}
