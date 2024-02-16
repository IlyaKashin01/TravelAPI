using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Settings : BaseEntity
    {
        public string NameSetting { get; set; } = string.Empty;
        public string NameGroup { get; set; } = string.Empty;
        public bool Status { get; set; }
        public List<SettingsJoinToPerson> Users { get; set; } = new List<SettingsJoinToPerson>();
    }
}