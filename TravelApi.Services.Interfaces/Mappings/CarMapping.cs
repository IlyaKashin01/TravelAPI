using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Category;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class CarMapping: Profile
    {
        public CarMapping()
        {
            CreateMap<CarRequest, Car>();

            CreateMap<Car, CarResponse>();
        }
    }
}
