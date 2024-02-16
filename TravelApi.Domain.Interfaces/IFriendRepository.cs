using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Friend;

namespace TravelApi.Domain.Interfaces
{
    public interface IFriendRepository: IBaseRepository<Friend>
    {
        Task<PaginationResponse<Friend>> GetAllFriends(PaginationRequest paginationRequest);

        Task<bool> UpdateFriendAsync(Friend request);

        Task<Friend?> FindFriend(int idOne, int IdTwo);
        Task<IEnumerable<Friend?>> FindFriendsAsync(string searchValue, int personId);
    }
}
