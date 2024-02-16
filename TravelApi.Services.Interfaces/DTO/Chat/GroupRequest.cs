using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Chat
{
    public class GroupRequest
    {
        public string Name { get; set; } = string.Empty;
        public int CreatorId { get; set; }
    }
}