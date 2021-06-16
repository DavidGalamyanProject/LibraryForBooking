using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IWarehouseManager
    {
        /// <summary>Загружает список товаров со склада, используется только при запуске сервера </summary>
        Task UploadProductList();
        void UpdateProductWarehouse(ImmutableDictionary<string, int> productWarehouse);
    }
}
