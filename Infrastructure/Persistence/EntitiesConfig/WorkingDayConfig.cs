using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntitiesConfig
{
    internal class WorkingDayConfig : IEntityTypeConfiguration<WorkingDay>
    {
        public void Configure(EntityTypeBuilder<WorkingDay> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.RestaurantId);

            builder.HasIndex(x => x.EmployeeId);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.WorkingDays)
                .HasForeignKey(x => x.EmployeeId);

            builder.Property(x => x.ShiftStartAt)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.ShiftEndAt)
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
