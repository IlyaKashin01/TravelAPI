using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Category;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/car")]
    [ApiController]
   // [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _categoryService;

        public CarController(ICarService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("createCar")]
        public async Task<ActionResult<OperationResult<int>>> CreateCar(CarRequest request)
        {
            var response = await _categoryService.CreateCarAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updateCategory")]
        public async Task<ActionResult<OperationResult>> UpdateCategory(CarRequest request)
        {
            var response = await _categoryService.UpdateCarAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deleteCategory")]
        public async Task<ActionResult<OperatingSystem>> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCarAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
