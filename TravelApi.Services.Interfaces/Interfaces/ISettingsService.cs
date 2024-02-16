using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Settings;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface ISettingsService
    {
        Task<OperationResult<bool>> ChangeStatusAsync(int PersonId, string settingName);
        Task<OperationResult<SettingsResponse>> GetSettingAsync(int personId, string nameSetting);
        Task<OperationResult> AssignSettingsToPersonAsync(AssignSettingsToPersonRequest request);
    }
}