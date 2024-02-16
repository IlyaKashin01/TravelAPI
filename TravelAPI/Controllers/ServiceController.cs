using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Infrastructure.Business;
using TravelApi.Services.Interfaces.DTO.Service;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/service")]
    [ApiController]
    //[Authorize]
    public class ServiceController: ControllerBase
    {
        private readonly IServicingService _servicingService;

        public ServiceController(IServicingService servicingService)
        {
            _servicingService = servicingService;
        }

        [HttpGet("getAllServices")]
        public async Task<ActionResult<OperationResult<IEnumerable<ServiceResponse>>>> GetAllService(int _skip, int _take, int? _searchValue)
        {
            var request = new PaginationRequest
            {
                Skip = _skip,
                Take = _take,
                searchIntValue = _searchValue
            };

            var response = await _servicingService.GetAllServicesAsync(request);
            return Ok(response);
        }

        [HttpPost("createService")]
        public async Task<ActionResult<OperationResult<int>>> CreateService(ServiceRequest request)
        {
            var response = await _servicingService.CreateServiceAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updateService")]
        public async Task<ActionResult<OperationResult>> UpdateService(ServiceRequest request)
        {
            var response = await _servicingService.UpdateServiceAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updateCostsService")]
        public async Task<ActionResult<OperationResult>> UpdateCostsService(ServiceCostRequest request)
        {
            var response = await _servicingService.UpdateCostsServiceAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deleteService")]
        public async Task<ActionResult<OperatingSystem>> DeleteService(int id)
        {
            var response = await _servicingService.DeleteServiceAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
        
    }
}
