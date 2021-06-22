using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IReservationRepository
    {
		/// <summary> Резервирует один товар. </summary>
		void AddReserve(Reserv product);

		/// <summary> Резервирует список товаров. </summary>
		void AddReserveProducts(List<Reserv> product);

		/// <summary> Возвращает сипсок всех резервов (все заказы). </summary>
		ImmutableList<Reserv> GetReservProducts();

		/// <summary> Ищем резерв по Id. </summary>
		Task<Reserv> GetReservById(Guid id);
    }
}
