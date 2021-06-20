using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework.Configurations;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Reserv> Reserves { get; set; }
        public DbSet<Product> Products { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
