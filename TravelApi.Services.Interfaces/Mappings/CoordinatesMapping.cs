using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Coordinates;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class CoordinatesMapping: Profile
    {
        public CoordinatesMapping()
        {
            CreateMap<CoordinatesRequest, Coordinates>();
            CreateMap<Coordinates, CoordinatesResponse>();
        }
    }
}
