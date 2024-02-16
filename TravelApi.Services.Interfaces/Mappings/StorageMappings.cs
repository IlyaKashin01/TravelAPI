using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Storage;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class StorageMappings: Profile
    {
        public StorageMappings() 
        {
            CreateMap<Image, ImageResponse>();
            CreateMap<PersonFile, FileResponse>();
        }
    }
}
