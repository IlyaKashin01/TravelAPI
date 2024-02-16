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
    public class PersonConfig: BaseEntityConfig<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable("person");
            builder.Property(e => e.Login).HasColumnName("login");
            builder.Property(e => e.FirstName).HasColumnName("first_name");
            builder.Property(e => e.LastName).HasColumnName("last_name");
            builder.Property(e => e.MiddleName).HasColumnName("middle_name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            builder.Property(e => e.Role).HasColumnName("role");
            builder.Property(e => e.Verified).HasColumnName("verified");
            builder.Property(e => e.IsVerified).HasColumnName("is_verified");
            builder.Property(e => e.StorageId).HasColumnName("storage_id");

            
        }
    }
}
