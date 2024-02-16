using Microsoft.AspNetCore.SignalR;
using SwaggerGen.SignalR.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Chat;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Common.Chat
{
    [SignalRHub("chatHub")]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Receive", message);
        }

        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<OperationResult<bool>> SendMessage(int toUserId, string message)
        {
            var fromUserId = Context.UserIdentifier;
            if (fromUserId is not null)
            {
                var request = new Message { FromUserId = Int32.Parse(fromUserId), ToUserId = toUserId, Content = message };
                await _chatService.SendMessageAsync(request);
                return new OperationResult<bool>(true);
            }
            return new OperationResult<bool>(false);
        }

        public async Task<OperationResult<bool>> SendMessageToGroup(string groupName, string message)
        {
            var fromUserId = Context.UserIdentifier;
            if (fromUserId is not null)
            {
                var request = new Message
                {
                    FromUserId = Int32.Parse(fromUserId),
                    GroupName = groupName,
                    Content = message
                };
                await _chatService.SendMessageToGroupAsync(request);
                return new OperationResult<bool>(true);
            }
            return new OperationResult<bool>(false);
        }

        public async Task<OperationResult<bool>> JoinGroup(string groupName)
        {
            var userId = Context.UserIdentifier;
            if (userId is not null)
            {
                await _chatService.JoinGroupAsync(Int32.Parse(userId), groupName);
                return new OperationResult<bool>(true);
            }
            return new OperationResult<bool>(false);
        }

        public async Task<OperationResult<bool>> LeaveGroup(string groupName)
        {
            var userId = Context.UserIdentifier;
            if (userId is not null)
            {
                await _chatService.LeaveGroupAsync(Int32.Parse(userId), groupName);
                return new OperationResult<bool>(true);
            }
            return new OperationResult<bool>(false);
        }

        public async Task<IEnumerable<Person?>> GetUsersInGroup(int groupId)
        {
            return await _chatService.GetUsersInGroupAsync(groupId);
        }

        public async Task<OperationResult<IEnumerable<MessageResponse>>> GetMessagesBetweenUsers(int user2Id)
        {
            var user1Id = Context.UserIdentifier;
            if (user1Id is not null)
            {
                var messages = await _chatService.GetMessagesBetweenUsersAsync(Int32.Parse(user1Id), user2Id);
                return new OperationResult<IEnumerable<MessageResponse>>(messages);
            }
            return OperationResult<IEnumerable<MessageResponse>>.Fail(OperationCode.EntityWasNotFound, "сообщений не найдено");
        }

        public async Task<OperationResult<IEnumerable<MessageResponse>>> GetMessagesInGroup(int groupId)
        {
            var messages = await _chatService.GetMessagesInGroupAsync(groupId);
            if (messages is not null) return new OperationResult<IEnumerable<MessageResponse>>(messages);
            return OperationResult<IEnumerable<MessageResponse>>.Fail(OperationCode.EntityWasNotFound, "сообщений не найдено");
        }

        public async Task<OperationResult<bool>> DeleteMessage(int messageId)
        {
            if (await _chatService.DeleteMessageAsync(messageId) == true) return new OperationResult<bool>(true);
            return new OperationResult<bool>(false);
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (userId is not null) await Clients.AllExcept(userId).SendAsync("UserConnected", userId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (userId is not null) await Clients.AllExcept(userId).SendAsync("UserDisconnected", userId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}