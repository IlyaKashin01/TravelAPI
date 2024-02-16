using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Settings
{
    public class SettingsRequest
    {
        public int Id { get; set; } = 0;
        public string NameSetting { get; set; } = string.Empty;
        public string NameGroup { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}