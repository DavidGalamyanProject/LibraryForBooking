using ShopWebApi.Model.Entity;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IReservationRepository
    {
        /// <summary> Резервирует один товар </summary>
        void CreateReserve(ProductReserve product);
        /// <summary> Резервирует список товаров </summary>
        void AddReserveProducts(List<ProductReserve> product);
        /// <summary> Возвращает все зарезервированные товары (заказы) </summary>
        ImmutableList<ProductReserve> GetReservProducts();
    }
}
