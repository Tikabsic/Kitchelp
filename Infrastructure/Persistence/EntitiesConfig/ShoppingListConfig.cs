using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntitiesConfig
{
    internal class ShoppingListConfig : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(x => x.ListId);

            builder.HasIndex(x => x.ListId);

            builder.HasOne(x => x.Restaurant)
                .WithMany(x => x.ShoppingLists)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.ShoppingLists)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
