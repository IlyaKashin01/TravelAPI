using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Chat;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class ChatMapping: Profile
    {
        public ChatMapping()
        {
            CreateMap<Message, ChatMessage>();
            CreateMap<GroupRequest, GroupChatRoom>();
        }
    }
}