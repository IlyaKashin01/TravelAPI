using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Person
{
#nullable disable
    public class AddAvatarRequest
    {
        public int PersonId { get; set; } = 0;
        public IFormFile Avatar { get; set; }
    }
}
