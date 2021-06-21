using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IReservationManager
    {
        /// <summary> Резервирует список товаров, из синглтон Queue класса Accounting. </summary>
        void ReservProducts();

        /// <summary> Загружает в синглтон Dictionary, все резервы из базы данных. </summary>
        void UploadReservList();

        /// <summary> Ищем резерв по Id. </summary>
        Reserv GetReservById(Guid id);
    }
}
