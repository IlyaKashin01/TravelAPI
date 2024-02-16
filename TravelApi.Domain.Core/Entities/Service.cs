using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Service: BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal ExpectedCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal ProjectedCost { get; set; }

        public int JourneyId { get; set; }

        public Journey Journey { get; set; } = new Journey();
    }
}
