using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
    
        }

        public Task<PaginationResponse<Person>> GetAllPeopleAsync(PaginationRequest paginationRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> GetPersonByEmailAndPhoneAsync(string email, string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Phone == phoneNumber);
        }

        public async Task<Person?> GetPersonByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Login == login);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var updatePerson = await GetByIdAsync(person.Id);

            if(updatePerson == null) return false;

            updatePerson.Login = person.Login;
            updatePerson.FirstName = person.FirstName;
            updatePerson.LastName = person.LastName;
            updatePerson.MiddleName = person.MiddleName;
            updatePerson.Email = person.Email;
            updatePerson.Phone = person.Phone;
            updatePerson.PasswordHash = person.PasswordHash;
            updatePerson.Role = person.Role;
            updatePerson.Verified = person.Verified;
            updatePerson.IsVerified = person.IsVerified;
            updatePerson.PasswordReset= person.PasswordReset;
            updatePerson.Avatar = person.Avatar;
            updatePerson.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
