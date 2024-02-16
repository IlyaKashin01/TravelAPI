using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Coordinates
{
    public class CoordinatesResponse
    {
        public int id { get; set; } = 0;
        public double Latitube { get; set; } = 0;
        public double Longitude { get; set; } = 0;
    }
}
