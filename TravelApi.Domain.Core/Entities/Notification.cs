using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Notification : BaseEntity
    {
        public DateOnly DateEvent { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Viewed { get; set; }
        public Person Person { get; set; } = new Person();
        public int PersonId { get; set; }
    }
}