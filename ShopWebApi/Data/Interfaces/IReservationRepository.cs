using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ShopWebApi.Data.Interfaces
{
    public interface IReservationRepository
    {
        /// <summary> Резервирует один товар. </summary>
        void CreateReserve(Reserv product);

        /// <summary> Резервирует список товаров. </summary>
        void AddReserveProducts(List<Reserv> product);

        /// <summary> Возвращает сипсок всех резервов (все заказы). </summary>
        ImmutableList<Reserv> GetReservProducts();

        /// <summary> Ищем резерв по Id. </summary>
        Reserv GetReservById(Guid id);
    }
}
