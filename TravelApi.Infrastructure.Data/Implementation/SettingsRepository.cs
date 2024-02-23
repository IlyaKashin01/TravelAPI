using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class SettingsRepository : ISettingsRepository
    {
        protected readonly AppDbContext _context;

        public SettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAndBindingSettingsAsync(int personId)
        {
            var person = await _context.Users.FirstOrDefaultAsync(x => x.Id == personId);
            if (person is not null)
            {
                var settings = new List<Settings> {
                new Settings
                {
                    Id = 1,
                    NameSetting = "Двухэтапная аутентификация",
                    NameGroup = "Безопасность",
                    Status = false,
                    Person = person,
                    CreatedDate = DateTime.UtcNow
                },
                new Settings
                {
                    Id = 2,
                    NameSetting = "Закрытый профиль",
                    NameGroup = "Конфиденциальность",
                    Status = false,
                    Person = person,
                    CreatedDate = DateTime.UtcNow
                },
                new Settings
                {
                    Id = 3,
                    NameSetting = "Видимость облачного хранилища",
                    NameGroup = "Конфиденциальность",
                    Status = false,
                    Person = person,
                    CreatedDate = DateTime.UtcNow
                }
                };
                _context.Set<Settings>().AddRange(settings);
                person.Settings = settings;
                person.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeStatusAsync(int settingId)
        {
            var setting = await _context.Settings.FindAsync(settingId);
            if (setting is null) return false;
            setting.Status = true;
            setting.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Settings>> GetSettingsByPersonAsync(int PersonId)
        {
            return await _context.Settings.Include(x => x.Person).Where(x => x.Id == PersonId).ToListAsync();
        }

        public Task<bool> IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSettingsAsync(Settings settings)
        {
            var updatedSetting = await _context.Settings.FindAsync(settings.Id);
            if (updatedSetting is null) return false;
            updatedSetting.NameSetting = settings.NameSetting;
            updatedSetting.NameGroup = settings.NameGroup;
            updatedSetting.Status = settings.Status;
            updatedSetting.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Settings?> GetSettingByPersonAsync(int PersonId, string settingName)
        {
            return await _context.Settings.Include(x => x.Person).Where(x => x.Id == PersonId).FirstOrDefaultAsync(x => x.NameSetting == settingName);
        }
    }
}