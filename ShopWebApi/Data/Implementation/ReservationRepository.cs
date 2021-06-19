using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ShopWebApi.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ShopDbContext _dbContext;

        public ReservationRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateReserve(Reserv product)
        {
            _dbContext.ReservedProducts.Add(product);
            _dbContext.SaveChanges();
        }
        public void AddReserveProducts(List<Reserv> product)
        {
            _dbContext.ReservedProducts.AddRange(product);
            _dbContext.SaveChanges();
        }

        public ImmutableDictionary<Guid, Guid> GetReservProducts()
        {
            var result = _dbContext.ReservedProducts.ToImmutableDictionary( x => x.IdOrder, x => x.IdOrder);
            return result;
        }
    }
}
