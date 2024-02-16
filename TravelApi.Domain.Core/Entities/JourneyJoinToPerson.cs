using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class JourneyJoinToPerson: BaseEntity
    {
        public Journey? Journey { get; set; } 
        public int JourneyId { get; set; } 

        public Person? Person { get; set; }
        public int PersonId { get; set; }
    }
}
