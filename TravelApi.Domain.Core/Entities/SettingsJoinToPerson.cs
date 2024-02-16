using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class SettingsJoinToPerson: BaseEntity
    {
        public int SettingId { get; set; }
        public Settings Settings { get; set; } = new Settings();
        public int PersonId { get; set; }
        public Person Person { get; set; } = new Person();
    }
}