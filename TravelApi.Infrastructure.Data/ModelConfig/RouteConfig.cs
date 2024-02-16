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
    public class RouteConfig: BaseEntityConfig<Route>
    {
        public override void Configure(EntityTypeBuilder<Route> builder)
        {
            base.Configure(builder);
            builder.ToTable("route");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Status).HasColumnName("status");
        }
    }
}
