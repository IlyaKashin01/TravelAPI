using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Settings>> GetAllSettingsAsync()
        {
            return await _context.Settings.ToListAsync();
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
            return await _context.SettingsJoinToUsers.Include(x => x.Settings).Where(x => x.PersonId == PersonId).Select(x => x.Settings).ToListAsync();
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
            return await _context.SettingsJoinToUsers.Include(x => x.Settings).Where(x => x.PersonId == PersonId).Select(x => x.Settings).FirstOrDefaultAsync(x => x.NameSetting == settingName);
        }
    }
}