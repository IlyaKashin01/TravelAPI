using System.Text.Json.Serialization;
using TravelApi.Common.JsonConverter;
using TravelApi.Services.Interfaces.DTO.Category;
using TravelApi.Services.Interfaces.DTO.Coordinates;
using TravelApi.Services.Interfaces.DTO.Person;
using TravelApi.Services.Interfaces.DTO.Service;

namespace TravelApi.Services.Interfaces.DTO.Journey
{
    public class JourneyResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateStart { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateEnd { get; set; }
        public decimal ExpectedCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal ProjectedCost { get; set; }
        public int CountDays { get; set; } = 0;
        public int CountPerson { get; set; } = 0;
    }
}
