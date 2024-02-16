using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Service;

namespace TravelApi.Domain.Interfaces
{
    public interface IServiceRepository: IBaseRepository<Service>
    {
        Task<Service?> GetServiceByNameAsync(string name);
        Task<PaginationResponse<Service>> GetAllServicesAsync(PaginationRequest pagination);
        Task<bool> UpdateServiceAsync(Service service);
        Task<bool> UpdateCostsServiceAsync(Service service);
    }
}
