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
    public class PersonFileConfig: BaseEntityConfig<PersonFile>
    {
        public override void Configure(EntityTypeBuilder<PersonFile> builder)
        {
            base.Configure(builder);
            builder.ToTable("person_file");
            builder.Property(e => e.FileName).HasColumnName("file_name");
            builder.Property(e => e.FileType).HasColumnName("file_type");
            builder.Property(e => e.FilePath).HasColumnName("file_path");
        }
    }
}
