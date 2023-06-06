using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntitiesConfig
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.CreatorId, x.ReciverId })
                .IsUnique();

            builder.HasOne(x => x.Revicer)
                .WithMany(x => x.Chats)
                .HasForeignKey(x => x.ReciverId);
        }
    }
}
