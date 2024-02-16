using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class MessageJoinToGroup: BaseEntity
    {
        public ChatMessage? Message { get; set; }
        public int MessageId { get; set; }
        public GroupChatRoom? Group { get; set; }
        public int GroupId { get; set; }
    }
}
