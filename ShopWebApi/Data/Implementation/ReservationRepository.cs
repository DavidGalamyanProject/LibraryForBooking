using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ShopDbContext _dbContext;

        public ReservationRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		public void AddReserve(Reserv product)
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

        public async Task<Reserv> GetReservById(Guid id)
        {
            var result = await _dbContext.Reserves.FindAsync(id);
            return result;
        }
    }
}
