using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Image
{
    public class ImagesRequest
    {
        public IFormFileCollection formFiles { get; set; } = new FormFileCollection();
    }
}
