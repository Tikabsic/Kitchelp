

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntitiesConfig
{
    internal class RestaurantConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.RestaurantName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NIP)
                .IsRequired()
                .HasMaxLength(13);

            builder.HasIndex(x => x.NIP);

            builder.Property(x => x.Address)
                .IsRequired();

            builder.Property(x => x.DateOfJoin)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DateOfPayment)
                .ValueGeneratedOnUpdate();

            builder.HasMany(x => x.Employees)
                .WithMany(e => e.Jobs)
                .UsingEntity<RestaurantEmployee>(
                    j => j.HasOne(re => re.Employee).WithMany().OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne(re => re.Restaurant).WithMany().OnDelete(DeleteBehavior.Restrict))
                .HasKey(re => new { re.RestaurantId, re.EmployeeId });
        }
    }
}
