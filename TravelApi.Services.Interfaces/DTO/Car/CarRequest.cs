using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Category
{
    public class CarRequest
    {
        public int Id { get; set; }
        public string Brand { get; set; } = "";
        public string Number { get; set; } = "";
        public string Expenditure { get; set; } = "";

    }
}
