using ShopWebApi.Model.Entity;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
	public interface IReservationManager
    {
		/// <summary> Резервирует список товаров, из синглтон Queue класса Accounting. </summary>
		void ReservProducts();

		/// <summary> Ищем резерв по Id. </summary>
		Task<Reserv> GetReservById(Guid id);
    }
}
