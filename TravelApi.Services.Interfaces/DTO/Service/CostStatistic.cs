using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Service
{
    public class CostStatistic
    {
        public decimal TotalCost { get; set; } = 0;
        public decimal MinCost { get; set; } = 0;
        public decimal MaxCost { get; set; } = 0;
    }
}
