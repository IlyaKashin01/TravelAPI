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
    public class ServiceConfig: BaseEntityConfig<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);
            builder.ToTable("service");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.ExpectedCost).HasColumnName("expected_cost");
            builder.Property(e => e.ActualCost).HasColumnName("actual_cost");
            builder.Property(e => e.ProjectedCost).HasColumnName("projected_cost");
            builder.Property(e => e.JourneyId).HasColumnName("journey_id");
        }
    }
}
