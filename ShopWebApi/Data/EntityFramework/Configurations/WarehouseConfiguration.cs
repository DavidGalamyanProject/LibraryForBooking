using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<StockPosition>
    {
        public void Configure(EntityTypeBuilder<StockPosition> builder)
        {
            builder.ToTable("warehouse");

            builder.HasKey(key => key.VendorCode);

            builder.Property(x => x.VendorCode)
                   .ValueGeneratedNever()
                   .HasColumnName("vendor_code");

            builder.Property(x => x.Quantity)
                   .ValueGeneratedNever()
                   .HasColumnName("quantity");

            builder.HasOne(warehouse => warehouse.Product)
                   .WithMany(product => product.Warehouse)
                   .HasForeignKey("product_id");
        }
    }
}
