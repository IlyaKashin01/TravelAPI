using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Auth;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Friend;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class FriendService : IFriendServise
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IDecodingJWT _decodingJWT;

        public FriendService(IFriendRepository friendRepository, IMapper mapper, IPersonRepository personRepository, IDecodingJWT decodingJWT)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
            _personRepository = personRepository;
            _decodingJWT = decodingJWT;
        }

        public async Task<OperationResult<int>> AddFriendAsync(AddFriendRequest request)
        {
            if (await _friendRepository.FindFriend(request.PersonOne, request.PersonTwo) is not null)
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Пользователь уже добавлен в друзья");
            var friend = _mapper.Map<Friend>(request);

            var person = await _personRepository.GetByIdAsync(request.PersonOne);
            if (person is not null)
            {
                friend.PersonId = person.Id;
                friend.Person = person;
            }
            friend.CreatedDate = new DateTime();
            friend.Status = Status.Sent;

            var result = await _friendRepository.CreateAsync(friend);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult<FriendResponse>> CheckFriendship(int oneId, int twoId)
        {
            var result = await _friendRepository.FindFriend(oneId, twoId);
            if (result is not null)
            {
                var response = _mapper.Map<FriendResponse>(result); 
                return new OperationResult<FriendResponse>(response);
            }
            return OperationResult<FriendResponse>.Fail(OperationCode.EntityWasNotFound, "Пользователь не добавлен в друзья");
        }

        public async Task<OperationResult> ConfirmFriendshipRequest(ConfirmFriendRequest request)
        {
            var friendship = await _friendRepository.GetByIdAsync(request.key);

            if (friendship is null)
                return OperationResult.Fail(OperationCode.EntityWasNotFound, "Запрос добавления в друзья не зарегестрирован");

            friendship.Status = Status.Confirmed;

            if (await _friendRepository.UpdateFriendAsync(friendship)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }

        public async Task<OperationResult> DeleteFriendAsync(int id)
        {
            var deletedFriend = await _friendRepository.DeleteAsync(id);

            if (deletedFriend) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Ошибка удаления");
        }

        public async Task<OperationResult<PaginationResponse<FriendResponse>>> GetAllFriendsAsync(PaginationRequest request)
        {
            var friends = await _friendRepository.GetAllFriends(request);

            if (friends is null) 
                return OperationResult<PaginationResponse<FriendResponse>>.Fail(OperationCode.EntityWasNotFound, "Нет добавленных друзей");

            var result = _mapper.Map<PaginationResponse<FriendResponse>>(friends);
            foreach (var friend in result.Items)
            {
                if(friend.PersonOne == request.searchIntValue)
                {
                    var person = await _personRepository.GetByIdAsync(friend.PersonTwo);
                    if (person is not null)
                    {
                        friend.Login = person.Login;
                        friend.FirstName= person.FirstName;
                        friend.LastName= person.LastName;
                        friend.MiddleName = person.MiddleName;
                        friend.Avatar = person.Avatar;
                    }
                }
                if(friend.PersonTwo == request.searchIntValue)
                {
                    var person = await _personRepository.GetByIdAsync(friend.PersonTwo);
                    if (person is not null)
                    {
                        friend.Login = person.Login;
                        friend.FirstName = person.FirstName;
                        friend.LastName = person.LastName;
                        friend.MiddleName = person.MiddleName;
                        friend.Avatar = person.Avatar;
                    }
                }
            }

            return new OperationResult<PaginationResponse<FriendResponse>>(result);
        }

        public async Task<OperationResult<SearchFriendResponse>> GetSearchFriendResultAsync(string searchValue, string token)
        {
            var personId = _decodingJWT.getJWTTokenClaim(token, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid");
            if (personId is not null) {
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    var friends = await _friendRepository.FindFriendsAsync(searchValue, person.Id);
                    if (friends is null)
                        return OperationResult<SearchFriendResponse>.Fail(OperationCode.EntityWasNotFound, "Нет результатов");

                    var response = new SearchFriendResponse();
                    foreach (var friend in _mapper.Map<IEnumerable<FriendResponse>>(friends.Where(x => x!.Status == Status.Confirmed).ToList()))
                        response.AddedFriendResult.Add(friend);
                    foreach (var friend in _mapper.Map<IEnumerable<FriendResponse>>(friends.Where(x => x!.Status == Status.Sent).ToList()))
                        response.NoAddedFriendResult.Add(friend);
                    foreach (var friend in response.AddedFriendResult)
                    {
                        if (friend.PersonOne == person.Id)
                        {
                            var friendProfile = await _personRepository.GetByIdAsync(friend.PersonTwo);
                            if (friendProfile is not null)
                            {
                                friend.Login = friendProfile.Login;
                                friend.FirstName = friendProfile.FirstName;
                                friend.LastName = friendProfile.LastName;
                                friend.MiddleName = friendProfile.MiddleName;
                                friend.Avatar = friendProfile.Avatar;
                            }
                        }
                        if (friend.PersonTwo == person.Id)
                        {
                            var friendProfile = await _personRepository.GetByIdAsync(friend.PersonTwo);
                            if (friendProfile is not null)
                            {
                                friend.Login = friendProfile.Login;
                                friend.FirstName = friendProfile.FirstName;
                                friend.LastName = friendProfile.LastName;
                                friend.MiddleName = friendProfile.MiddleName;
                                friend.Avatar = friendProfile.Avatar;
                            }
                        }
                    }
                    foreach (var friend in response.NoAddedFriendResult)
                    {
                        if (friend.PersonOne == person.Id)
                        {
                            var friendProfile = await _personRepository.GetByIdAsync(friend.PersonTwo);
                            if (friendProfile is not null)
                            {
                                friend.Login = friendProfile.Login;
                                friend.FirstName = friendProfile.FirstName;
                                friend.LastName = friendProfile.LastName;
                                friend.MiddleName = friendProfile.MiddleName;
                                friend.Avatar = friendProfile.Avatar;
                            }
                        }
                        if (friend.PersonTwo == person.Id)
                        {
                            var friendProfile = await _personRepository.GetByIdAsync(friend.PersonTwo);
                            if (friendProfile is not null)
                            {
                                friend.Login = friendProfile.Login;
                                friend.FirstName = friendProfile.FirstName;
                                friend.LastName = friendProfile.LastName;
                                friend.MiddleName = friendProfile.MiddleName;
                                friend.Avatar = friendProfile.Avatar;
                            }
                        }
                    }
                    return response is null ?
                        OperationResult<SearchFriendResponse>.Fail(OperationCode.Error, "Ошибка генерации ответа")
                        :
                        new OperationResult<SearchFriendResponse>(response);
                }
            }
            return OperationResult<SearchFriendResponse>.Fail(OperationCode.Unauthorized, "Пользователь не авторизован");
        }
    }


}
