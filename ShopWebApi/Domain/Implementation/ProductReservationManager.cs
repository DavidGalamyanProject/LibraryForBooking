using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class ProductReservationManager : IProductReservationManager
    {
        private readonly IProductReservationRepository _reservRepository;
        private readonly IProductInWarehouseRepository _warehouse;

        public ProductReservationManager(IProductReservationRepository reservRepository, IProductInWarehouseRepository warehouse)
        {
            _reservRepository = reservRepository;
            _warehouse = warehouse;
        }
        public async Task<ReserveProductResponse> MakeAReservationProduct(ProductReservRequest request,DateTime timeNow)
        {
            var result = await _warehouse.TryGetProduct(request);
            if( result == null )
            {
                return default;
            }
            var reserveProduct = new ReservedProducts()
            {
                IdOrder = Guid.NewGuid(),
                ProductName = result.ProductName,
                Quantity = request.Quantity,
                ReservationTime = timeNow
            };
            _reservRepository.CreateReserve(reserveProduct);

            return new ReserveProductResponse() { Id = reserveProduct.IdOrder };

        }
    }
}
