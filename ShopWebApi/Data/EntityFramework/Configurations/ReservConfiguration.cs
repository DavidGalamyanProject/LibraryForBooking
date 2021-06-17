using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class ReservConfiguration : IEntityTypeConfiguration<ProductReserve>
    {
        public void Configure(EntityTypeBuilder<ProductReserve> builder)
        {
            builder.ToTable("reserved_products");

            builder.HasKey(key => key.IdOrder);

            builder.Property(x => x.IdOrder)
                   .ValueGeneratedNever()
                   .HasColumnName("id_order");
        }
    }
}
