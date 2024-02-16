using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Parsing
{
    public class ParamsHotels
    {
        public string City { get; set; } = string.Empty;
        public string NameMonthFrom { get; set; } = string.Empty;
        public string DayFrom { get; set; } = string.Empty;
        public string NameMonthAnd { get; set; } = string.Empty;
        public string DayAnd { get; set; } = string.Empty;
        public int CountPersons { get; set; } = 0;
    }
}
