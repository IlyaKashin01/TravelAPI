using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Chat;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IChatService
    {
        Task SendMessageAsync(Message request);
        Task SendMessageToGroupAsync(Message request);
        Task JoinGroupAsync(int userId, string groupName);
        Task LeaveGroupAsync(int userId, string groupName);
        Task<IEnumerable<Person?>> GetUsersInGroupAsync(int groupId);
        Task<IEnumerable<MessageResponse>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id);
        Task<IEnumerable<MessageResponse>> GetMessagesInGroupAsync(int groupId);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
