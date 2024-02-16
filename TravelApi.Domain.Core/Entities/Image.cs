using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Byte[] Data { get; set; } = new Byte[0];
        public int PostId { get;set; } = 0;
        public Post Post { get; set; } = new Post();
        public int StorageId { get; set; } = 0;
        public Storage Storage { get; set; } = new Storage();
    }
}
