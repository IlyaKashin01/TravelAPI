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
    public class FriendConfig: BaseEntityConfig<Friend>
    {
        public override void Configure(EntityTypeBuilder<Friend> builder)
        {
            base.Configure(builder);
            builder.ToTable("friend");
            builder.Property(e => e.PersonOne).HasColumnName("person_one");
            builder.Property(e => e.PersonTwo).HasColumnName("person_two");
            builder.Property(e => e.Status).HasColumnName("status");
            builder.Property(e => e.PersonId).HasColumnName("person_id");

            
        }
    }
}
