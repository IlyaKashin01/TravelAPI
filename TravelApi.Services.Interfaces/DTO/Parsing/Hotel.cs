using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Parsing
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CountStars { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string Price { get; set; } = string.Empty;
        public string CountNights { get; set; } = string.Empty;
        public List<string> SrcImages { get; set; } = new List<string>();
    }
}
