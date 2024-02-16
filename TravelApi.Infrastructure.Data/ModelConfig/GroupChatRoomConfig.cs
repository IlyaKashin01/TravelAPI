using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Infrastructure.Data.ModelConfig
{
    public class GroupChatRoomConfig: BaseEntityConfig<GroupChatRoom>
    {
        public override void Configure(EntityTypeBuilder<GroupChatRoom> builder)
        {
            base.Configure(builder);
            builder.ToTable("group_chat_room");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.CreatorId).HasColumnName("creator_id");
        }
    }
}
