using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CountLike { get; set; } = 0;
        public int CountDisLike { get; set; } = 0;
        public int CountShare { get; set; } = 0;
        public List<Image> images { get; set; } = new List<Image>();
        public int PersonId { get; set; } = 0;
        public Person Person { get; set; } = new Person();
    }
}
