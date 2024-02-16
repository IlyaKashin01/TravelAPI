using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Infrastructure.Data.ModelConfig
{
    public class SettingsConfig : BaseEntityConfig<Settings>
    {
        public override void Configure(EntityTypeBuilder<Settings> builder)
        {
            base.Configure(builder);
            builder.ToTable("settings");
            builder.Property(e => e.NameSetting).HasColumnName("name_setting");
            builder.Property(e => e.NameGroup).HasColumnName("name_group");
            builder.Property(e => e.Status).HasColumnName("status");
            // builder.Property(e => e.Users).HasColumnName("users");

            builder.HasData(new Settings[]{
                new Settings{
                    Id = 1,
                    NameSetting = "Двухэтапная аутентификация",
                    NameGroup = "Безопасность",
                    Status = false,
                },
                new Settings{
                    Id = 2,
                    NameSetting = "Закрытый профиль",
                    NameGroup = "Конфиденциальность",
                    Status = false,
                },
                new Settings{
                    Id = 3,
                    NameSetting = "Видимость облачного хранилища",
                    NameGroup = "Конфиденциальность",
                    Status = false,
                }
            });
        }
    }
}