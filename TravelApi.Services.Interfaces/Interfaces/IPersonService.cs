using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Person;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IPersonService
    {
        Task<OperationResult<bool>> AddAvatar(IFormFile image, string token);
        Task<OperationResult> UpdatePersonAsync(PersonRequest request);
        Task<OperationResult> DeletePersonAsync(int id);
    }
}
