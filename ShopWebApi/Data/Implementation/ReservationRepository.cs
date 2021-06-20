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
            _dbContext.Reserves.Add(product);
            _dbContext.SaveChanges();
        }
        public void AddReserveProducts(List<Reserv> product)
        {
            _dbContext.Reserves.AddRange(product);
            _dbContext.SaveChanges();
        }

        public ImmutableList<Reserv> GetReservProducts()
        {
            var result = _dbContext.Reserves.ToImmutableList();
            return result;
        }

        public Reserv GetReservById(Guid id)
        {
            var result = _dbContext.Reserves.Find(id);
            return result;
        }
    }
}
