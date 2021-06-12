using ShopWebApi.Model.Dto;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IProductReservationManager
    {
        Task<ReserveProductResponse> MakeAReservationProduct(ProductReservRequest request, DateTime timeNow);
    }
}
