using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Chat
{
    public class MessageResponse
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int? GroupId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}