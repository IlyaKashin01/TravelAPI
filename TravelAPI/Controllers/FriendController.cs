using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Services.Interfaces.DTO.Friend;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/friend")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendServise _friendServise;

        public FriendController(IFriendServise friendServise)
        {
            _friendServise = friendServise;
        }

        [HttpGet("getAllFriends")]
        public async Task<ActionResult<OperationResult<PaginationResponse<FriendResponse>>>> GetAllFriends(int skip, int take, int searchIntValue)
        {
            var request = new PaginationRequest { Skip = skip, Take = take, searchIntValue = searchIntValue, searchStringValue = "" };
            var response = await _friendServise.GetAllFriendsAsync(request);
            return Ok(response);
        }

        [HttpPost("addFriend")]
        public async Task<ActionResult<OperationResult<int>>> AddFriend(AddFriendRequest request)
        {
            var response = await _friendServise.AddFriendAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("confirmFriend")]
        public async Task<ActionResult<OperationResult>> ConfirmFriend(ConfirmFriendRequest request)
        {
            var response = await _friendServise.ConfirmFriendshipRequest(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("checkFriendship")]
        public async Task<ActionResult<OperationResult>> CheckFriendship(int oneId, int twoId)
        {
            var response = await _friendServise.CheckFriendship(oneId, twoId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("searchFriends"), Authorize]
        public async Task<ActionResult<OperationResult>> SearchFriends(string searchValue)
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _friendServise.GetSearchFriendResultAsync(searchValue, authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }
            return BadRequest("Ошибка получения токена авторизации");
        }

        [HttpDelete("deleteFriend")]
        public async Task<ActionResult<OperationResult>> DeleteFriend(int id)
        {
            var response = await _friendServise.DeleteFriendAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
