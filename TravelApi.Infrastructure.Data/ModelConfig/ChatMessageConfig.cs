using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Infrastructure.Data.ModelConfig
{
    public class ChatMessageConfig: BaseEntityConfig<ChatMessage>
    {
        public override void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            base.Configure(builder);
            builder.ToTable("message");
            builder.Property(e => e.FromUserId).HasColumnName("from_person_id");
            builder.Property(e => e.ToUserId).HasColumnName("to_person_id");
            builder.Property(e => e.Content).HasColumnName("content");
            builder.Property(e => e.SentAt).HasColumnName("sent_at");
        }
    }
}
