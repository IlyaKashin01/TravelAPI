using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Storage;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IStorageService
    {
        Task<OperationResult<int>> CreateStorageAsync(string token);
        Task<OperationResult<bool>> SaveFileAsync(IFormFileCollection files, string token);
        Task<OperationResult> DeleteFileAsync(string token, string storageId, string fileName);
        Task<OperationResult<StorageFilesResponse>> GetAllFilesAsync(string token);
    }
}
