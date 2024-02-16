using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Post
{
    public class PostResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int CountLike { get; set; } = 0;
        public int CountDisLike { get; set; } = 0;
        public int CountShare { get; set; } = 0;
        public List<string> PathImages { get; set; } = new List<string>();
    }
}
