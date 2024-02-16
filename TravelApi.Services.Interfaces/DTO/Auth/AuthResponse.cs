using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Services.Interfaces.DTO.Person;

namespace TravelApi.Services.Interfaces.DTO.Auth
{
#nullable disable
    public class AuthResponse
    {
        public PersonResponse Person { get; set; }
        public string Token { get; set; }
    }
}
