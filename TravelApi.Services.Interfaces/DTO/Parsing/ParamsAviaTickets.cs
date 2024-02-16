using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Parsing
{
    public class ParamsAviaTickets
    {
        public string WhereFrom { get; set; } = string.Empty;
        public string Where { get; set; } = string.Empty;
        public string MonthFrom { get; set; } = string.Empty;
        public string DayFrom { get; set; } = string.Empty;
        public string MonthAnd { get; set; } = string.Empty;
        public string DayAnd { get; set; } = string.Empty;
        public int Adults { get; set; }
        public string TravelClass { get; set; } = string.Empty;
    }
}
