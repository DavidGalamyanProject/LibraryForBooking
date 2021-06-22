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
		Task CreateReserve(Reserv product);

		/// <summary> Резервирует список товаров. </summary>
		Task AddReserveProducts(List<Reserv> product);

        /// <summary> Возвращает сипсок всех резервов (все заказы). </summary>
        ImmutableList<Reserv> GetReservProducts();

		/// <summary> Ищем резерв по Id. </summary>
		Task<Reserv> GetReservById(Guid id);
    }
}
