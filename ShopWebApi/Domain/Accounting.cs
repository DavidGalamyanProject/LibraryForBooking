using ShopWebApi.Model.Dto;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ShopWebApi.Domain
{
	/// <summary> Списки учета, с их помощью снимается нагрузка с БД 
	/// Поверх конкурентной очереди, реализованная своя система лока
	/// Потому что, когда необходимо получить из очереди лист обектов
	/// Мы должны быть уверены, что другие потоки в данный момент, коллекция не используется
	/// и будет доступна только после действия!</summary>
	internal class Accounting
	{

		private static readonly object _lock = new object();
		private static ConcurrentQueue<ReservRequestToQueue> _reservRequestToQueues;		
		private Accounting() { }
		/// <summary> Метод добавление, в очередь </summary>
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
		/// <summary> Метод получения списка объекта из очереди </summary>
		public static ImmutableList<ReservRequestToQueue> GetAllReservs()
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
				var result = _reservRequestToQueues.ToImmutableList();
				_reservRequestToQueues.Clear();
				return result;
			}
		}
	}
}
