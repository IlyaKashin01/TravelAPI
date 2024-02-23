using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface ISettingsRepository
    {
        Task<IEnumerable<Settings>> GetSettingsByPersonAsync(int PersonId);
        Task<Settings?> GetSettingByPersonAsync(int PersonId, string settingName);
        Task<bool> UpdateSettingsAsync(Settings settings);
        Task<bool> ChangeStatusAsync(int settingId);
        Task<bool> CreateAndBindingSettingsAsync(int personId);
    }
}