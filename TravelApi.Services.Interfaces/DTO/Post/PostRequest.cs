using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Post
{
    public class PostRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int PersonId { get; set; } = 0;

        public IFormFileCollection Files { get; set; } = new FormFileCollection();
    }
}
