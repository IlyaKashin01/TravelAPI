using AutoMapper;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Settings;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class SettingsMapping : Profile
    {
        public SettingsMapping()
        {
            CreateMap<SettingsRequest, Settings>();
            CreateMap<Settings, SettingsResponse>();
        }
    }
}