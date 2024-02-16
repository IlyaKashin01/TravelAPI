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
    public class JourneyJoinToPersonConfig: BaseEntityConfig<JourneyJoinToPerson>
    {
        public override void Configure(EntityTypeBuilder<JourneyJoinToPerson> builder)
        {
            base.Configure(builder);
            builder.ToTable("journey_join_to_person");
            builder.Property(e => e.JourneyId).HasColumnName("journey_id");
            builder.Property(e => e.PersonId).HasColumnName("person_id");

            
        }
    }
}
