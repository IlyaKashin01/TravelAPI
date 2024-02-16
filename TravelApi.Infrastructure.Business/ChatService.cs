using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Chat;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Chat;
using TravelApi.Services.Interfaces.DTO.Person;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IHubContext<ChatHub> hubContext, IGroupRepository groupRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _hubContext = hubContext;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task SendMessageAsync(Message request)
        {
            var newMessage = _mapper.Map<ChatMessage>(request);
            await _chatRepository.CreateAsync(newMessage);
            await _hubContext.Clients.Client(request.ToUserId.ToString()).SendAsync("ReceiveMessage", newMessage);
        }

        public async Task SendMessageToGroupAsync(Message request)
        {
            var group = await _groupRepository.getGroupByNameAndUsersAsync(request.GroupName, request.FromUserId);
            if (group is not null)
            {
                var newMessage = _mapper.Map<ChatMessage>(request);
                newMessage.Groups.Add(new MessageJoinToGroup { Group = group, Message = newMessage});
                await _chatRepository.CreateAsync(newMessage);
                await _hubContext.Clients.Group(group.Name).SendAsync("ReceiveMessage", newMessage);
            }
        }
        public async Task<OperationResult<int>> CreateGroupAsync(GroupRequest request)
        {
            if (await _groupRepository.getGroupByNameAndCreatorAsync(request.Name, request.CreatorId) is not null)
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Групповой чат уже создан");
            var group = _mapper.Map<GroupChatRoom>(request);
            var result = await _groupRepository.CreateAsync(group);
            return new OperationResult<int>(result);
        }

        public async Task JoinGroupAsync(int userId, string groupName)
        {
            await _hubContext.Groups.AddToGroupAsync(userId.ToString(), groupName);
            await _hubContext.Clients.Group(groupName).SendAsync("UserJoined", userId);
        }

        public async Task LeaveGroupAsync(int userId, string groupName)
        {
            await _hubContext.Groups.RemoveFromGroupAsync(userId.ToString(), groupName);
            await _hubContext.Clients.Group(groupName).SendAsync("UserLeft", userId);
        }

        public async Task<IEnumerable<Person?>> GetUsersInGroupAsync(int groupId)
        {
            return await _chatRepository.GetUsersInGroupAsync(groupId);
        }

        public async Task<IEnumerable<MessageResponse>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id)
        {
            var messages = await _chatRepository.GetMessagesBetweenUsersAsync(user1Id, user2Id);
            var result = _mapper.Map<IEnumerable<MessageResponse>>(messages);
            return result;
        }

        public async Task<IEnumerable<MessageResponse>> GetMessagesInGroupAsync(int groupId)
        {
            var messages = await _chatRepository.GetMessagesInGroupAsync(groupId);
            var result = _mapper.Map<IEnumerable<MessageResponse>>(messages);
            return result;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            if (await _chatRepository.DeleteAsync(messageId)) return true;
            return false;
        }
    }
}
