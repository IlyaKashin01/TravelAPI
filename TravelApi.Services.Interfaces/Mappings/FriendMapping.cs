using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Friend;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class FriendMapping: Profile
    {
        public FriendMapping()
        {
            CreateMap<AddFriendRequest, Friend>();
            CreateMap<ConfirmFriendRequest, Friend>();

            CreateMap<Friend, FriendResponse>();
            CreateMap<PaginationResponse<Friend>, PaginationResponse<FriendResponse>>();
        }
    }
}
