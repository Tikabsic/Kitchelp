using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntitiesConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.WarehouseId);

            builder.Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
