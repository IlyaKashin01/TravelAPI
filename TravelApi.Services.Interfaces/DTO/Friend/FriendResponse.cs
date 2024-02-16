using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Services.Interfaces.DTO.Friend
{
    public class FriendResponse
    {
        public int Id { get; set; }
        public int PersonOne { get; set; }
        public int PersonTwo { get; set; }
        public Status Status { get; set; }
        public string Login { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public Byte[]? Avatar { get; set; }
    }
}
