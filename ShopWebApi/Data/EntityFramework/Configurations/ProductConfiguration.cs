using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(key => key.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .HasColumnName("id");

            builder.Property(x => x.ProductName)
                   .ValueGeneratedNever()
                   .HasColumnName("product_name");

            builder.Property(x => x.ProductInformation)
                   .ValueGeneratedNever()
                   .HasColumnName("product_information");
        }

    }
}
