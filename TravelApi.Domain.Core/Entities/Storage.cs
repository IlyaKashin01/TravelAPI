using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Storage: BaseEntity
    {
        public List<PersonFile> PersonFiles { get; set; } = new List<PersonFile>();
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
