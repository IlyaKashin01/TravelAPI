using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Journey;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class JourneyMapping: Profile
    {
        public JourneyMapping()
        {
            CreateMap<JourneyRequest, Journey>();

            CreateMap<Journey, JourneyResponse>();
            CreateMap<PaginationResponse<Journey>, PaginationResponse<JourneyResponse>>();
        }
    }
}
