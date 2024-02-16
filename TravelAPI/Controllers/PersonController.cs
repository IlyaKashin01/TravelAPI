using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Person;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPut("addAvatar"), Authorize]
        public async Task<ActionResult<OperationResult>> AddAvatarToPerson ( IFormFile image)
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _personService.AddAvatar(image, authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }

            return BadRequest("error");
        }

        [HttpPut("updatePerson"), Authorize]
        public async Task<ActionResult<OperationResult>> UpdatePerson(PersonRequest person)
        {
            var response = await _personService.UpdatePersonAsync(person);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deletePerson"), Authorize]
        public async Task<ActionResult<OperatingSystem>> DeletePerson (int id)
        {
            var response = await _personService.DeletePersonAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
