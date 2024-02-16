using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Auth;
using TravelApi.Services.Interfaces.DTO.Person;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class PersonMapping: Profile
    {
        public PersonMapping()
        {
            CreateMap<AuthRequest, Person>();
            CreateMap<SignupRequest, Person>();
            CreateMap<PersonRequest, Person>();
            CreateMap<PersonRequest, Person>();

            CreateMap<Person, AuthResponse>();
            CreateMap<Person, PersonResponse>();
        }
    }
}
