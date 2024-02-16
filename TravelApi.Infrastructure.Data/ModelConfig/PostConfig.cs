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
    public class PostConfig: BaseEntityConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
            builder.ToTable("post");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.CountLike).HasColumnName("count_like");
            builder.Property(e => e.CountDisLike).HasColumnName("count_dis_like");
            builder.Property(e => e.CountShare).HasColumnName("count_share");
            builder.Property(e => e.PersonId).HasColumnName("person_id");
        }
    }
}
