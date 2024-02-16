using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Services.Interfaces.DTO.Journey;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/journey")]
    [ApiController]
    [Authorize]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpGet("getAllJourney")]
        public async Task<ActionResult<OperationResult<IEnumerable<JourneyResponse>>>> GetAllJourneys (int _skip, int _take, int? _searchValue)
        {
            var request = new PaginationRequest
            {
                Skip = _skip,
                Take = _take,
                searchIntValue = _searchValue
            };

            var response = await _journeyService.GetAllJourneyAsync(request);
            return Ok(response);
        }

        [HttpPost("createJourney")]
        public async Task<ActionResult<OperationResult<int>>> CreateJourney(JourneyRequest request)
        {
            var response = await _journeyService.CreateJourneyAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("addPersonToJourney")]
        public async Task<ActionResult<OperationResult>> AddPersonToJourney (AddPersonToJourneyRequest request)
        {
            var response = await _journeyService.AddPersonToJourneyAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updateJourney")]
        public async Task<ActionResult<OperationResult>> UpdateJourney (JourneyRequest request)
        {
            var response = await _journeyService.UpdateJourneyAsync(request);
            if(response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updateCostsJourney")]
        public async Task<ActionResult<OperationResult>> UpdateCostsJourney(JourneyRequest request)
        {
            var response = await _journeyService.UpdateCostsJourneyAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deleteJourney")]
        public async Task<ActionResult<OperationResult>> DeleteJourney (int id)
        {
            var response = await _journeyService.DeleteJourneyAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("getJourneyById")]
        public async Task<ActionResult<OperationResult<JourneyResponse>>> GetJourneyById(int id)
        {
            var response = await _journeyService.GetByIdJourneyAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
