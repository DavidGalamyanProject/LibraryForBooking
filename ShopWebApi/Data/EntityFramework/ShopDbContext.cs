using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework.Configurations;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        public DbSet<WarehouseProduct> Warehouse { get; set; }
        public DbSet<ReservedProduct> ReservedProducts { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
        }
    }
}
