using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Parsing
{
    public class Flight
    {
        public int Id { get; set; } = 0;
        public string FromAirline { get; set; } = string.Empty;
        public string BackAirline { get; set; } = string.Empty;
        public string FromDepartureTime { get; set; } = string.Empty;
        public string FromArrivalTime { get; set; } = string.Empty;
        public string BackDepartureTime { get; set; } = string.Empty;
        public string BackArrivalTime { get; set; } = string.Empty;
        public string FromTimeline { get; set; } = string.Empty;
        public string BackTimeline { get; set; } = string.Empty;
        public string FromTypeFlight { get; set; } = string.Empty;
        public string BackTypeFlight { get; set; } = string.Empty;
        public string FromDepartureAirport { get; set; } = string.Empty;
        public string FromArrivalAirport { get; set; } = string.Empty;
        public string BackDepartureAirport { get; set; } = string.Empty;
        public string BackArrivalAirport { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
