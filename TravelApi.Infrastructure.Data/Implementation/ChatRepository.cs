using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Chat;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class ChatRepository : BaseRepository<ChatMessage>, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ChatMessage>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id)
        {
            return await _context.ChatMessages.Where(x => x.FromUserId == user1Id || x.FromUserId == user2Id &&
             x.ToUserId == user1Id || x.ToUserId == user2Id).ToListAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetMessagesInGroupAsync(int groupId)
        {
            return await _context.ChatMessages.Include(x => x.Groups).Where(x => x.Id == groupId).ToListAsync();
        }

        public async Task<IEnumerable<Person?>> GetUsersInGroupAsync(int groupId)
        {
            return await _context.Groups.Where(x => x.Id == groupId)
                                        .SelectMany(x => x.Users)
                                        .Select(x => x.Person)
                                        .ToListAsync();
        }

        public Task UpdateMessageAsync(ChatMessage message)
        {
            throw new NotImplementedException();
        }
    }
}