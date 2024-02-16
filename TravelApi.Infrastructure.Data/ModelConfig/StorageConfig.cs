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
    public class StorageConfig: BaseEntityConfig<Storage>
    {
        public override void Configure(EntityTypeBuilder<Storage> builder)
        {
            base.Configure(builder);
            builder.ToTable("storage");
            builder.Property(e => e.Id).HasColumnName("Id");

           
        }
    }
}
