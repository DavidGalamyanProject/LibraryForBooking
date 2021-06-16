using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IReservationManager
    {
        /// <summary> Добавляет запрос на резерв товара, если в момент регистрации резерва товар был на складе, он будет зарезервирован  </summary>
        ReserveProductResponse AddRequestToQueue(ProductReservRequest request);
        /// <summary> Резервирует список товаров </summary>
        
        /// <summary> Загружает список зарезервированных товаров (заказов), используется только при запуске сервера </summary>
        void UploadReservList();
    }
}
