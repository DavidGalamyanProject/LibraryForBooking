﻿using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Entity;
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

        public void CreateReserve(ProductReserve product)
        {
            _dbContext.ReservedProducts.Add(product);
            _dbContext.SaveChanges();
        }
        public void AddReserveProducts(List<ProductReserve> product)
        {
            _dbContext.ReservedProducts.AddRange(product);
            _dbContext.SaveChanges();
        }

        public ImmutableList<ProductReserve> GetReservProducts()
        {
            var result = _dbContext.ReservedProducts.ToImmutableList();
            return result;
        }
    }
}