﻿
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Persistence.EntitiesConfig
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.DateOfJoin)
                .ValueGeneratedOnAdd();


            builder.HasMany(x => x.Chats)
                    .WithOne(x => x.Creator)
                    .HasForeignKey(x => x.CreatorId);
        }
    }
}