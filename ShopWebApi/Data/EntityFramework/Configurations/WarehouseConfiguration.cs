using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("warehouse");

            builder.HasKey(key => key.Article);

            builder.Property(x => x.Article)
                   .ValueGeneratedNever()
                   .HasColumnName("article");

            builder.Property(x => x.Quantity)
                   .ValueGeneratedNever()
                   .HasColumnName("quantity");

            builder.HasOne(warehouse => warehouse.Product)
                   .WithMany(product => product.Warehouse)
                   .HasForeignKey("product_id");
        }
    }
}
