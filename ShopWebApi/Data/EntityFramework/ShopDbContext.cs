using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data.EntityFramework.Configurations;
using ShopWebApi.Model;

namespace ShopWebApi.Data.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        public DbSet<ProductInWarehouse> StorageWarehouse { get; set; }
        public DbSet<ReservedProducts> ReservedOrders { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservedOrderConfiguration());
            modelBuilder.ApplyConfiguration(new StorageWarehouseConfiguration());
        }
    }
}
