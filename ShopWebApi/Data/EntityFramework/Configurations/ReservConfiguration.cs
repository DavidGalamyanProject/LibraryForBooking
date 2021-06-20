using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class ReservConfiguration : IEntityTypeConfiguration<Reserv>
    {
        public void Configure(EntityTypeBuilder<Reserv> builder)
        {
            builder.ToTable("reserved");

            builder.HasKey(key => key.IdOrder);

            builder.Property(x => x.IdOrder)
                   .ValueGeneratedNever()
                   .HasColumnName("IdOrder");

            builder.Property(x => x.Quantity)
                   .ValueGeneratedNever()
                   .HasColumnName("Qantity");

            builder.Property(x => x.ReservationTime)
                   .ValueGeneratedNever()
                   .HasColumnName("ReservationTime");

            builder.HasOne(reserv => reserv.Product)
                   .WithMany(product => product.Reserve)
                   .HasForeignKey("ProductId");
        }
    }
}
