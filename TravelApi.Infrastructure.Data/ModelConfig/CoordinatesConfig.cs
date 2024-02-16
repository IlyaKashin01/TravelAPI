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
    public class CoordinatesConfig: BaseEntityConfig<Coordinates>
    {
        public override void Configure(EntityTypeBuilder<Coordinates> builder)
        {
            base.Configure(builder);
            builder.ToTable("coordinates");
            builder.Property(e => e.NamePlace).HasColumnName("name_place");
            builder.Property(e => e.Latitube).HasColumnName("latitube");
            builder.Property(e => e.Longitude).HasColumnName("longitude");
            builder.Property(e => e.JourneyId).HasColumnName("journey_id");
            builder.Property(e => e.RouteId).HasColumnName("route_id");
        }
    }
}
