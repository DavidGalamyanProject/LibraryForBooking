using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IProductManager
    {
        /// <summary> Возвращает товар по имени </summary>
        Product GetProductByName(string productName);

        /// <summary> Создает Entity товара и добавляет его в базу данных </summary>
        /// <returns> Id созданого товара </returns>
        Task<Guid> CreateProduct(ProductRequest request);
    }
}
