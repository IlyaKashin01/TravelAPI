using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IJourneyRepository: IBaseRepository<Journey>
    {
        Task<PaginationResponse<Journey>> GetAllJourneyAsync(PaginationRequest paginationRequest);
        Task<Journey?> GetJourneyByNameAsync(string name);  
        Task<bool> UpdateJourneyAsync(Journey journey);
        Task<bool> UpdateCostsJourneyAsync(int journeyId);
    }
}
