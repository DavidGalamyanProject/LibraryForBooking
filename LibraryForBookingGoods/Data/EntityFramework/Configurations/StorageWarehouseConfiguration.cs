using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class StorageWarehouseConfiguration : IEntityTypeConfiguration<ProductInWarehouse>
    {
        public void Configure(EntityTypeBuilder<ProductInWarehouse> builder)
        {
            builder.ToTable("storage_warehouse");

            builder.Property(x => x.Article)
                   .ValueGeneratedNever()
                   .HasColumnName("article");
        }
    }
}
