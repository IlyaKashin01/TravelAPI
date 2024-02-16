using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IPersonRepository: IBaseRepository<Person>
    {
        Task<PaginationResponse<Person>> GetAllPeopleAsync(PaginationRequest paginationRequest);
        Task<Person?> GetPersonByLoginAsync(string login);
        Task<Person?> GetPersonByEmailAndPhoneAsync(string email, string phoneNumber);

        Task<bool> UpdatePersonAsync(Person person);
    }
}
