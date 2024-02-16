using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Journey;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ICarRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public JourneyService(IJourneyRepository journeyRepository, IMapper mapper, ICarRepository categoryRepository, IPersonRepository personRepository)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _personRepository = personRepository;
        }

        public async Task<OperationResult<int>> CreateJourneyAsync(JourneyRequest request)
        {
            if ( await _journeyRepository.GetJourneyByNameAsync(request.Name) is not null)
                return OperationResult<int>.Fail(
                    OperationCode.AlreadyExists,
                    $"Путешествие с названием {request.Name} существует");

            var journey = _mapper.Map<Journey>(request);
            journey.CountDays = new DateTime(request.DateEnd.Year, request.DateEnd.Month, request.DateEnd.Day).Subtract(new DateTime(request.DateStart.Year, request.DateStart.Month, request.DateStart.Day)).Days;
            journey.CreatedDate = DateTime.UtcNow;
            var person = await _personRepository.GetByIdAsync(request.PersonId);
            if (person is not null) {
                journey.Users.Add(new JourneyJoinToPerson { Journey = journey, Person = person});
                journey.CountPerson = 1;
            }
            var result = await _journeyRepository.CreateAsync(journey);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult> AddPersonToJourneyAsync(AddPersonToJourneyRequest request)
        {
            var journey = await _journeyRepository.GetByIdAsync(request.IdJourney);
            var person = await _personRepository.GetByIdAsync(request.IdPerson); 
            if (person is not null && journey is not null)
            {
                journey.Users.Add(new JourneyJoinToPerson { Journey = journey, Person = person });
                journey.CountPerson += 1;
                await _journeyRepository.UpdateJourneyAsync(journey);
                return OperationResult.OK;
            }
            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Путешествия или пользователя не существует");
        }

        public async Task<OperationResult> DeleteJourneyAsync(int id)
        {
            var deletedJourney = await _journeyRepository.DeleteAsync(id);

            if (deletedJourney) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Путешествие не найдено");
        }

        public async Task<OperationResult<PaginationResponse<JourneyResponse>>> GetAllJourneyAsync(PaginationRequest request)
        {
            var journeys = await _journeyRepository.GetAllJourneyAsync(request);

            var response = _mapper.Map<PaginationResponse<JourneyResponse>>(journeys);

            return new OperationResult<PaginationResponse<JourneyResponse>>(response);
        }

        public async Task<OperationResult> UpdateJourneyAsync(JourneyRequest request)
        {
            if (await _journeyRepository.GetJourneyByNameAsync(request.Name) is null)
                return OperationResult.Fail(
                    OperationCode.EntityWasNotFound,
                    $"Путешествия с названием {request.Name} не найдено");

            var updateJourney = _mapper.Map<Journey>(request);

            if (await _journeyRepository.UpdateJourneyAsync(updateJourney)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }

        public async Task<OperationResult> UpdateCostsJourneyAsync(JourneyRequest request)
        {
             var updateJourney = await _journeyRepository.GetJourneyByNameAsync(request.Name);
            if (updateJourney is null)
                return OperationResult.Fail(
                    OperationCode.EntityWasNotFound,
                    $"Путешествия с названием {request.Name} не найдено");

            if (await _journeyRepository.UpdateCostsJourneyAsync(updateJourney.Id)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }

        public async Task<OperationResult<JourneyResponse>> GetByIdJourneyAsync(int Id)
        {
            var journey = await _journeyRepository.GetByIdAsync(Id);
            if (journey is not null)
            {
                var result = _mapper.Map<JourneyResponse>(journey);
                return new OperationResult<JourneyResponse>(result);
            }
            return OperationResult<JourneyResponse>.Fail(OperationCode.EntityWasNotFound, "Путешествия не существует");
        }
    }
}
