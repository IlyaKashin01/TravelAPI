using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Settings;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/settings")]
    [ApiController]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("getsetting")]
        public async Task<ActionResult<OperationResult>> GetSettingsAsync(int personId, string nameString)
        {
            var response = await _settingsService.GetSettingAsync(personId, nameString);
            if(response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("assignsettins")]
        public async Task<ActionResult<OperationResult>> AssignSettinsToPersonAsync(AssignSettingsToPersonRequest request)
        {
            var response = await _settingsService.BindingSettingsToPersonAsync(request);
            if( response.Success ) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("changestatus")]
        public async Task<ActionResult<OperationResult<bool>>> ChangeStatusSettingAsync(int PersonId, string settingName)
        {
            var response = await _settingsService.ChangeStatusAsync(PersonId, settingName);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
