using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Chat;

namespace TravelApi.Domain.Interfaces
{
    public interface IChatRepository : IBaseRepository<ChatMessage>
    {
        Task<IEnumerable<Person?>> GetUsersInGroupAsync(int groupId);
        Task<IEnumerable<ChatMessage>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id);
        Task<IEnumerable<ChatMessage>> GetMessagesInGroupAsync(int groupId);
        Task UpdateMessageAsync(ChatMessage message);
    }
}
