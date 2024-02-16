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
    public class ImageConfig: BaseEntityConfig<Image>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);
            builder.ToTable("image");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Data).HasColumnName("data");
            builder.Property(e => e.PostId).HasColumnName("post_id");
            builder.Property(e => e.StorageId).HasColumnName("storage_id");
        }
    }
}
