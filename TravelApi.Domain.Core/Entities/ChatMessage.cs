using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class ChatMessage: BaseEntity
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public List<MessageJoinToGroup> Groups { get; set; } = new List<MessageJoinToGroup>();
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
