using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Car: BaseEntity
    {
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Expenditure { get; set; } = string.Empty;
        public Person Person { get; set; } = new Person();
        public int PersonId { get; set; }
    }
}
