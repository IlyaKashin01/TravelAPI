using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Storage;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("createSrogage")]
        public async Task<ActionResult<OperationResult<int>>> CreateStorage ()
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _storageService.CreateStorageAsync(authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
            }

            return BadRequest(OperationResult.Fail(OperationCode.Unauthorized, "Пользователь не авторизован"));
        }

        [HttpPost("saveFile")]
        [RequestSizeLimit(100_000_000_000)]
        public async Task<ActionResult<OperationResult<bool>>> SaveFile([FromForm] IFormFileCollection files)
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _storageService.SaveFileAsync(files, authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
            }

            return BadRequest(OperationResult.Fail(OperationCode.Unauthorized, "Пользователь не авторизован"));
        }

        [HttpGet("getAllFiles")]
        public async Task<ActionResult<OperationResult<StorageFilesResponse>>> GetAllFiles()
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _storageService.GetAllFilesAsync(authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
            }

            return BadRequest(OperationResult.Fail(OperationCode.Unauthorized, "Пользователь не авторизован"));
        }
    }
}
