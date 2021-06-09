using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class ReservedOrderConfiguration : IEntityTypeConfiguration<ReservedOrder>
    {
        public void Configure(EntityTypeBuilder<ReservedOrder> builder)
        {
            builder.ToTable("reserved_orders");

            builder.Property(x => x.IdOrder)
                   .ValueGeneratedNever()
                   .HasColumnName("id_order");
        }
    }
}
