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
    public class NotificationConfig: BaseEntityConfig<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);
            builder.ToTable("notification");
            builder.Property(e => e.DateEvent).HasColumnName("date_event");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.Viewed).HasColumnName("viewed");
        }
    }
}
