using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Coordinates;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly ICoordinatesRepository _coordinatesRepository;
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;

        public CoordinatesService(ICoordinatesRepository coordinatesRepository, IMapper mapper, IJourneyRepository journeyRepository)
        {
            _coordinatesRepository = coordinatesRepository;
            _mapper = mapper;
            _journeyRepository = journeyRepository;
        }

        public async Task<OperationResult<int>> CreateCoordinatesAsync(CoordinatesRequest request)
        {
            if (await _coordinatesRepository.GetByJourneyIdAsync(request.JourneyId, request.Latitube, request.Longitude) is not null)
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Координаты уже добавлены в путешествие");
            var coordinates = _mapper.Map<Coordinates>(request);
            coordinates.CreatedDate = DateTime.UtcNow;
            var journey = await _journeyRepository.GetByIdAsync(request.JourneyId);
            if (journey is null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Привязка координат к не существующему путешествию");
            else coordinates.Journey = journey;

            var result = await _coordinatesRepository.CreateAsync(coordinates);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult> DeleteCoordinatesAsync(int id)
        {
            var deletedCoordinates = await _coordinatesRepository.DeleteAsync(id);

            if (deletedCoordinates) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Координат не существует");
        }

        public async Task<OperationResult<IEnumerable<CoordinatesResponse>>> GetAllCoordintesAsync(int id)
        {
            var result = await _coordinatesRepository.GetAllCoordinatesAsync(id);
            var response = _mapper.Map<IEnumerable<CoordinatesResponse>> (result);
            return new OperationResult<IEnumerable<CoordinatesResponse>>(response);
        }

        public async Task<OperationResult> UpdateCoordinatesAsync(CoordinatesRequest request)
        {
            if ( await _coordinatesRepository.GetByJourneyIdAsync(request.JourneyId, request.Latitube, request.Longitude) is null)
                return OperationResult.Fail(OperationCode.EntityWasNotFound, "Координаты не найдены");

            var updatedCoordinates = _mapper.Map<Coordinates>(request);
            var journey = await _journeyRepository.GetByIdAsync(request.JourneyId);
            if (journey is null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Привязка координат к не существующему путешествию");
            else updatedCoordinates.Journey = journey;

            if(await _coordinatesRepository.UpdateCoordinatesAsync(updatedCoordinates)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }
    }
}
