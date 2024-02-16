using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Image
{
    public class AddImagesRequest
    {
        public int Id { get; set; }
        public IFormFileCollection files { get; set; } = new FormFileCollection();
    }
}
