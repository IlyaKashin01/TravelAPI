using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Category;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface ICarService
    {
        Task<OperationResult<int>> CreateCarAsync(CarRequest request);
        Task<OperationResult> UpdateCarAsync(CarRequest request);
        Task<OperationResult> DeleteCarAsync(int id);
    }
}
