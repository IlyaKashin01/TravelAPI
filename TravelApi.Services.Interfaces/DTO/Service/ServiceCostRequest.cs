using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Service
{
    public class ServiceCostRequest
    {
        public int Id { get; set; } = 0;
        public decimal ExpectedCost { get; set; }
        public decimal ActualCost { get; set; }
    }
}
