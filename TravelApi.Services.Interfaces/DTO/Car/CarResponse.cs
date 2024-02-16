using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Category
{
    public class CarResponse
    {
        public int Id { get; set; } = 0;
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Expenditure { get; set; } = string.Empty;
    }
}
