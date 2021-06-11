using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model;

namespace ShopWebApi.Data.Implementation
{
    public class ProductReservationRepository : IProductReservationRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductReservationRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateReserve(ReservedProducts product)
        {
            _dbContext.ReservedOrders.Add(product);
            _dbContext.SaveChanges();
        }
    }
}
