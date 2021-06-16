using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebApi.Model.Entity;

namespace ShopWebApi.Data.EntityFramework.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<WarehouseProduct>
    {
        public void Configure(EntityTypeBuilder<WarehouseProduct> builder)
        {
            builder.ToTable("warehouse");

            builder.HasKey(key => key.Article);

            builder.Property(x => x.Article)
                   .ValueGeneratedNever()
                   .HasColumnName("article");
        }
    }
}
