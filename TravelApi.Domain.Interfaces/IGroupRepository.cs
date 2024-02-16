using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IGroupRepository : IBaseRepository<GroupChatRoom>
    {
        public Task<GroupChatRoom?> getGroupByNameAndCreatorAsync(string groupName, int CreatorId);
        public Task<GroupChatRoom?> getGroupByNameAndUsersAsync(string groupName, int PersonId);
    }
}