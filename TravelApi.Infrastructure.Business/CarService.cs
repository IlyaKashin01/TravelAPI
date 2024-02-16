using AutoMapper;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Category;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IJourneyRepository _journeyRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper, IJourneyRepository journeyRepository, IPersonRepository personRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _journeyRepository = journeyRepository;
            _personRepository = personRepository;
        }

        public async Task<OperationResult<int>> CreateCarAsync(CarRequest request)
        {
            if (await _carRepository.CheckExistCarAsync(1))
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, $"Автомобиль уже добавлен");

            var car = _mapper.Map<Car>(request);
            car.CreatedDate = DateTime.UtcNow;
            var person = await _personRepository.GetByIdAsync(1);
            if (person is not null)
            {
                car.PersonId = 1;
                car.Person = person;
            }
            var result = await _carRepository.CreateAsync(car);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult> DeleteCarAsync(int id)
        {
            var deletedCategory = await _carRepository.DeleteAsync(id);

            if (deletedCategory) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Автомобиля не существует");
        }
        public async Task<OperationResult> UpdateCarAsync(CarRequest request)
        {
            if (!await _carRepository.CheckExistCarAsync(request.Id))
                return OperationResult.Fail(OperationCode.EntityWasNotFound, $"Автомобиль не найден");

            var updateCar = _mapper.Map<Car>(request);

            if(await _carRepository.UpdateCarAsync(updateCar)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }
    }
}
