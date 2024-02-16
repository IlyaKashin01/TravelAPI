using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Auth
{
    public class AuthRequest
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
