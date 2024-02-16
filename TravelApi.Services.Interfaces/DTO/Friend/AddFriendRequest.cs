using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Friend
{
    public class AddFriendRequest
    {
        public int PersonOne { get; set; } = 0;

        public int PersonTwo { get; set; } = 0;
    }
}
