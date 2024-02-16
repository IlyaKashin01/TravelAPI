using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Services.Interfaces.DTO.Friend;
using TravelApi.Services.Interfaces.DTO.Journey;

namespace TravelApi.Services.Interfaces.DTO.Person
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Login { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public Byte[] Avatar { get; set; } = new Byte[0];
    }
}
