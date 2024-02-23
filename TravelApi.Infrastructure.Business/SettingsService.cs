using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Settings;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class SettingsService : ISettingsService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;

        public SettingsService(IPersonRepository personRepository, ISettingsRepository settingsRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> BindingSettingsToPersonAsync(AssignSettingsToPersonRequest request)
        {
            var personSettings = await _settingsRepository.GetSettingsByPersonAsync(request.PersonId);
            if (!personSettings.Any())
            {
                var settings = await _settingsRepository.CreateAndBindingSettingsAsync(request.PersonId);
                
                return OperationResult.OK;
            };
            return OperationResult.Fail(OperationCode.Error, "Настройки уже привязаны к пользователю");
        }
        public async Task<OperationResult<bool>> ChangeStatusAsync(int PersonId, string settingName)
        {
            var existSetting = await _settingsRepository.GetSettingByPersonAsync(PersonId, settingName);
            if (existSetting is null)
                return OperationResult<bool>.Fail(OperationCode.EntityWasNotFound, "Настройка не найдена");
            if (await _settingsRepository.ChangeStatusAsync(existSetting.Id)) return new OperationResult<bool>(true);
            return OperationResult<bool>.Fail(OperationCode.Error, "Не удалось обновить статус настройки");
        }

        public async Task<OperationResult<SettingsResponse>> GetSettingAsync(int personId, string nameSetting)
        {
            var setting = await _settingsRepository.GetSettingByPersonAsync(personId, nameSetting);
            if(setting != null)
            {
                var response = _mapper.Map<SettingsResponse>(setting);
                return new OperationResult<SettingsResponse>(response);
            }
            return OperationResult<SettingsResponse>.Fail(OperationCode.EntityWasNotFound, "Настройка не найдена");
        }
    }
}