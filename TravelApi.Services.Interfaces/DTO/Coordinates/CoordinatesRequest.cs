using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Coordinates
{
    public class CoordinatesRequest
    {
        public double Latitube { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public int JourneyId { get; set; } = 0;
    }
}
