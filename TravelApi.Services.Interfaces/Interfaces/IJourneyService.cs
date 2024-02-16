using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Services.Interfaces.DTO.Journey;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IJourneyService
    {
        Task<OperationResult<int>> CreateJourneyAsync(JourneyRequest request);
        Task<OperationResult> AddPersonToJourneyAsync(AddPersonToJourneyRequest request);
        Task<OperationResult> UpdateJourneyAsync(JourneyRequest request);
        Task<OperationResult> DeleteJourneyAsync(int id);
        Task<OperationResult<PaginationResponse<JourneyResponse>>> GetAllJourneyAsync(PaginationRequest request);
        Task<OperationResult> UpdateCostsJourneyAsync(JourneyRequest request);
        Task<OperationResult<JourneyResponse>> GetByIdJourneyAsync(int Id);
    }
}
