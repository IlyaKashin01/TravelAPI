using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class EventsJourney : BaseEntity
    {
        public DateOnly DateEvent { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Journey Journey { get;set; } = new Journey();
        public int JourneyId { get; set; }

    }
}