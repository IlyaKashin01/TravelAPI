using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Friend;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(AppDbContext context) : base(context) { }

        public async Task<bool> UpdateFriendAsync(Friend request)
        {
            var updatedFriend = await GetByIdAsync(request.Id);

            if (updatedFriend == null) return false;

            updatedFriend.PersonOne = request.PersonOne;
            updatedFriend.PersonTwo = request.PersonTwo;
            updatedFriend.PersonId = request.PersonId;
            updatedFriend.Person = request.Person;
            updatedFriend.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResponse<Friend>> GetAllFriends(PaginationRequest paginationRequest)
        {
            var query = _context.Friends.Where(x => x.PersonOne == paginationRequest.searchIntValue || x.PersonTwo == paginationRequest.searchIntValue)
                .Where(x => x.Status == Status.Confirmed);
            
            var countPages = await query.CountAsync();

            query = query.Skip(paginationRequest.Skip).Take(paginationRequest.Take);

            return new PaginationResponse<Friend>
            {
                Items = await query.ToListAsync(),
                TotalCount = countPages
            };
        }

        public async Task<PaginationResponse<Friend>> GetAllRequestsFrienlyAsync(PaginationRequest paginationRequest)
        {
            var query = _context.Friends.Where(x => x.PersonOne == paginationRequest.searchIntValue || x.PersonTwo == paginationRequest.searchIntValue && x.Status == Status.Sent);

            var countPages = await query.CountAsync();

            query = query.Skip(paginationRequest.Skip).Take(paginationRequest.Take);

            return new PaginationResponse<Friend>
            {
                Items = await query.ToListAsync(),
                TotalCount = countPages
            };
        }

        public async Task<Friend?> FindFriend(int idOne, int IdTwo)
        {
            var result1 = await _context.Friends.Where(x => x.PersonOne == idOne )
                                         .FirstOrDefaultAsync(x => x.PersonTwo == IdTwo);
            if(result1 is null) return await _context.Friends.Where(x => x.PersonOne == IdTwo)
                                         .FirstOrDefaultAsync(x => x.PersonTwo == idOne);
            return result1;
        }

        public async Task<IEnumerable<Friend?>> FindFriendsAsync(string searchValue, int personId)
        {
            var person = await _context.Users.FirstOrDefaultAsync(x => x.Login == searchValue);

            string lastName = "";
            string firstName = "";
            string middleName = "";
            string[] nameParts = searchValue.Split(' ');
            if (nameParts.Length == 1)
            {
                var persons = await _context.Users.Where(x => x.FirstName == searchValue || x.LastName == searchValue || x.MiddleName == searchValue || x.Login == searchValue).ToListAsync();
                var result = new List<Friend>();
                foreach (var user in persons)
                {
                    var searchByFullName = await _context.Friends.Where(x => (x.PersonOne == user.Id || x.PersonTwo == user.Id) && (x.PersonOne == personId || x.PersonTwo == personId)).ToListAsync();
                    foreach (var friend in searchByFullName) result.Add(friend);

                }
                return result;
            }
            else
            {
                lastName = nameParts[1];
                firstName = nameParts[0];
                middleName = nameParts[2];
                var persons = await _context.Users.Where(x => x.FirstName == firstName && x.LastName == lastName && x.MiddleName == middleName).ToListAsync();
                var result = new List<Friend>();
                foreach (var user in persons)
                {
                    var searchByFullName = await _context.Friends.Where(x => (x.PersonOne == user.Id || x.PersonTwo == user.Id) && (x.PersonOne == personId || x.PersonTwo == personId)).ToListAsync();
                    foreach (var friend in searchByFullName) result.Add(friend);
                }
                return result;
            }
            
           /* if (person is not null)
            {
                var resultSearchByLogin = await _context.Friends.Where(x => (x.PersonOne == person.Id || x.PersonTwo == person.Id) && (x.PersonOne == personId || x.PersonTwo == personId)).ToListAsync();
                foreach (var friend in resultSearchByLogin) if(persons.Where(x => x.Login == person.Login).Count() == 0) result.Add(friend);
            }
            return result;*/
        }
    }
}
