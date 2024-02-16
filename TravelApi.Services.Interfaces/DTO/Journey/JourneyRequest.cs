using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TravelApi.Common.JsonConverter;

namespace TravelApi.Services.Interfaces.DTO.Journey
{
    public class JourneyRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateStart { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateEnd { get; set; }
        public int PersonId { get; set; } = 0;
    }
}
