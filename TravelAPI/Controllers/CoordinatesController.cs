using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Coordinates;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/coordinates")]
    [ApiController]
    public class CoordinatesController : ControllerBase
    {
        private readonly ICoordinatesService _coordinatesService;

        public CoordinatesController(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService;
        }

        [HttpGet("getAllCoordinates/{id}")]
        public async Task<ActionResult<OperationResult<IEnumerable<CoordinatesResponse>>>> GetAllCoordinates (int id)
        {
            var response = await _coordinatesService.GetAllCoordintesAsync(id);
            return Ok(response);
        }

        [HttpPost("createCoordinates")]
        public async Task<ActionResult<OperationResult<int>>> CreateCoordinates(CoordinatesRequest request)
        {
            var response = await _coordinatesService.CreateCoordinatesAsync(request);
            if(response.Success) return Ok(response); 
            return BadRequest(response);
        }

        [HttpPut("updateCoordinates")]
        public async Task<ActionResult<OperationResult>> UpdateCoordinates(CoordinatesRequest request)
        {
            var response = await _coordinatesService.UpdateCoordinatesAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deleteCoordinates")]
        public async Task<ActionResult<OperatingSystem>> DeleteCoordinates(int id)
        {
            var response = await _coordinatesService.DeleteCoordinatesAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
