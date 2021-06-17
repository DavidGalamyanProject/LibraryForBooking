using ShopWebApi.Model.Entity;
using System;

namespace ShopWebApi.Model.Dto
{
    public class Dto
    {
        private readonly ProductReserve _lockCreate = new ProductReserve();
        public ProductReserve CreateProductReserv(string productName, int quantity)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Negative quantity of goods.");
            }
            lock(_lockCreate)
            {
                _lockCreate.IdOrder = Guid.NewGuid();
                _lockCreate.ProductName = productName;
                _lockCreate.Quantity = quantity;
                _lockCreate.ReservationTime = DateTime.UtcNow;
            }
            return _lockCreate;
        }
    }
}
