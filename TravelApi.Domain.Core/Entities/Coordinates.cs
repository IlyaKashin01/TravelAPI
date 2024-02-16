using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Coordinates: BaseEntity
    {
        public string NamePlace { get; set; } = string.Empty;
        public double Latitube { get; set; }
        public double Longitude { get; set; }
        public Journey Journey { get; set; } = new Journey();
        public int JourneyId { get; set; }
        public Route Route { get; set; } = new Route();
        public int RouteId { get; set; }
    }
}
