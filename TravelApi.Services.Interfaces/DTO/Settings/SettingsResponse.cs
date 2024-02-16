using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Settings
{
    public class SettingsResponse
    {
        public string NameSetting { get; set; } = string.Empty;
        public string NameGroup { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
