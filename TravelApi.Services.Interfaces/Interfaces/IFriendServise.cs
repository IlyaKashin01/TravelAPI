using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Services.Interfaces.DTO.Friend;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IFriendServise
    {
        Task<OperationResult<int>> AddFriendAsync(AddFriendRequest request);
        Task<OperationResult> ConfirmFriendshipRequest(ConfirmFriendRequest request);
        Task<OperationResult> DeleteFriendAsync(int id);
        Task<OperationResult<PaginationResponse<FriendResponse>>> GetAllFriendsAsync(PaginationRequest request);
        Task<OperationResult<FriendResponse>> CheckFriendship (int oneId, int twoId);
        Task<OperationResult<SearchFriendResponse>> GetSearchFriendResultAsync(string searchValue, string token);
    }
}
