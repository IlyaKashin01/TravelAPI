using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Services.Interfaces.DTO.Service;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IServicingService
    {
        Task<OperationResult<int>> CreateServiceAsync(ServiceRequest request);
        Task<OperationResult> UpdateServiceAsync(ServiceRequest request);
        Task<OperationResult> DeleteServiceAsync(int id);
        Task<OperationResult<ServiceResponse>> GetServiceAsync(int id);
        Task<OperationResult<PaginationResponse<ServiceResponse>>> GetAllServicesAsync(PaginationRequest request);
        Task<OperationResult> UpdateCostsServiceAsync(ServiceCostRequest request);
    }
}
