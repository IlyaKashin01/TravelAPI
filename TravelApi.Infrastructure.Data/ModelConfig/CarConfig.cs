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
    public class CarConfig: BaseEntityConfig<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            base.Configure(builder);
            builder.ToTable("car");
            builder.Property(e => e.Brand).HasColumnName("brand");
            builder.Property(e => e.Number).HasColumnName("number");
            builder.Property(e => e.Expenditure).HasColumnName("expenditure");
            builder.Property(e => e.PersonId).HasColumnName("person_id");
           
        }
    }
}
