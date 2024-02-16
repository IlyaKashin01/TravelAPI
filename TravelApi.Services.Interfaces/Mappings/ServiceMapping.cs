using AutoMapper;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Service;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class ServiceMapping: Profile
    {
        public ServiceMapping()
        {
            CreateMap<ServiceRequest, Service>();
            CreateMap<ServiceCostRequest, Service>();
            CreateMap<Service, ServiceResponse>(); 
            CreateMap<PaginationResponse<Service>, PaginationResponse<ServiceResponse>>();
        }
    }
}
