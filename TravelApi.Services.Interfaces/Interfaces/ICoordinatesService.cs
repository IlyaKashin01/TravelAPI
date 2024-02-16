using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Coordinates;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface ICoordinatesService
    {
        Task<OperationResult<int>> CreateCoordinatesAsync(CoordinatesRequest request);
        Task<OperationResult> UpdateCoordinatesAsync(CoordinatesRequest request);
        Task<OperationResult> DeleteCoordinatesAsync(int id);
        Task<OperationResult<IEnumerable<CoordinatesResponse>>> GetAllCoordintesAsync(int id);
    }
}
