using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntitiesConfig
{
    internal class ShoppingListProductConfig : IEntityTypeConfiguration<ShoppingListProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingListProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.HasOne(x => x.ShoppingList)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ShoppingListId);

            builder.Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
