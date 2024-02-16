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
    public class JourneyConfig: BaseEntityConfig<Journey>
    {
        public override void Configure(EntityTypeBuilder<Journey> builder)
        {
            base.Configure(builder);
            builder.ToTable("journey");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.ExpectedCost).HasColumnName("expected_cost");
            builder.Property(e => e.ActualCost).HasColumnName("actual_cost");
            builder.Property(e => e.ProjectedCost).HasColumnName("projected_cost");
            builder.Property(e => e.DateStart).HasColumnName("date_start");
            builder.Property(e => e.DateEnd).HasColumnName("date_end");
            builder.Property(e => e.CategoryId).HasColumnName("category_id");
            builder.Property(e => e.CountDays).HasColumnName("count_days");
            builder.Property(e => e.CountPerson).HasColumnName("count_persons");
            
        }
    }
}
