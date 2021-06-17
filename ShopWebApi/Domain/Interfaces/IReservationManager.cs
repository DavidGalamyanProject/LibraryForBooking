using ShopWebApi.Model.Dto;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IReservationManager
    {
        /// <summary> Добавляет запрос на резерв товара, если в момент регистрации резерва товар был на складе, он будет зарезервирован  </summary>
        ReserveProductResponse AddRequestToQueue(ProductReservRequest request);
        /// <summary> Резервирует список товаров </summary>
        void ReservProducts();
        /// <summary> Загружает список зарезервированных товаров (заказов), используется только при запуске сервера </summary>
        void UploadReservList();
    }
}
