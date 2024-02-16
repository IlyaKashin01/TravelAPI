using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Journey
{
    public class AddPersonToJourneyRequest
    {
        public int IdPerson { get; set; } = 0;
        public int IdJourney { get; set; } = 0;
    }
}
