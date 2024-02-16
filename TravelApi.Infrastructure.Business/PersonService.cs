using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Auth;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Person;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IDecodingJWT _decodingJWT;

        public PersonService(IPersonRepository personRepository, IMapper mapper, IDecodingJWT decodingJWT)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _decodingJWT = decodingJWT;
        }

        public async Task<OperationResult<bool>> AddAvatar(IFormFile image, string token)
        {
            var personId = _decodingJWT.getJWTTokenClaim(token, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid");
            if (personId != null)
            {
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    using (var memory = new MemoryStream())
                    {
                        image.CopyTo(memory);
                        person.Avatar = memory.ToArray();
                    }
                    var result = await _personRepository.UpdatePersonAsync(person);
                    return new OperationResult<bool>(result);
                }
            }
            return OperationResult<bool>.Fail(OperationCode.EntityWasNotFound, $"Пользователя не существует.{personId}");            
        }

        public async Task<OperationResult> DeletePersonAsync(int id)
        {
            var deletedPerson = await _personRepository.DeleteAsync(id);

            if (deletedPerson) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Пользователя не существует");
        }

        public async Task<OperationResult> UpdatePersonAsync(PersonRequest request)
        {
            if (await _personRepository.GetPersonByLoginAsync(request.Login) is null)
                return OperationResult.Fail(OperationCode.EntityWasNotFound, $"Пользователя с логином {request.Login} не существует");

            var updatedPerson = _mapper.Map<Person>(request);

            if(await _personRepository.UpdatePersonAsync(updatedPerson)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }
    }
}
