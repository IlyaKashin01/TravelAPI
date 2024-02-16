using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Friend
{
    public class SearchFriendResponse
    {
        public List<FriendResponse> AddedFriendResult { get; set; } = new List<FriendResponse>();
        public List<FriendResponse> NoAddedFriendResult { get; set; } = new List<FriendResponse>();
    }
}
