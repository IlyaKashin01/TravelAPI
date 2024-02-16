using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class GroupRepository : BaseRepository<GroupChatRoom>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context) { }
        public async Task<GroupChatRoom?> getGroupByNameAndCreatorAsync(string groupName, int CreatorId)
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.Name == groupName && x.CreatorId == CreatorId);
        }

        public async Task<GroupChatRoom?> getGroupByNameAndUsersAsync(string groupName, int PersonId)
        {
            return await _context.Groups.Where(x => x.Name == groupName)
                                        .Include(x => x.Users)
                                        .FirstOrDefaultAsync(x => x.Id == PersonId);
        }
    }
}