using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class ReservedOrderConfiguration : IEntityTypeConfiguration<ReservedProducts>
    {
        public void Configure(EntityTypeBuilder<ReservedProducts> builder)
        {
            builder.ToTable("reserved_orders");

            builder.HasKey(key => key.IdOrder);

            builder.Property(x => x.IdOrder)
                   .ValueGeneratedNever()
                   .HasColumnName("id_order");
        }
    }
}
