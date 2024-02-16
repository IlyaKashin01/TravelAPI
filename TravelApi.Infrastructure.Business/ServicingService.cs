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
using TravelApi.Services.Interfaces.DTO.Service;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class ServicingService : IServicingService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;

        public ServicingService(IServiceRepository serviceRepository, IMapper mapper, IJourneyRepository journeyRepository)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _journeyRepository = journeyRepository;
        }

        public async Task<OperationResult<int>> CreateServiceAsync(ServiceRequest request)
        {
            if (await _serviceRepository.GetServiceByNameAsync(request.Name) is not null)
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Услуга уже добавлена");
            var service = _mapper.Map<Service>(request);
            service.JourneyId = request.JourneyId;
            service.ExpectedCost = request.Cost;
           var journey = await _journeyRepository.GetByIdAsync(request.JourneyId);
           if(journey is not null) service.Journey = journey;
       
            var result = await _serviceRepository.CreateAsync(service);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult> DeleteServiceAsync(int id)
        {
            var deletedService = await _serviceRepository.DeleteAsync(id);

            if (deletedService) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.EntityWasNotFound, "Услуга не найдена");
        }

        public async Task<OperationResult<PaginationResponse<ServiceResponse>>> GetAllServicesAsync(PaginationRequest request)
        {
            var services = await _serviceRepository.GetAllServicesAsync(request);

            var response = _mapper.Map<PaginationResponse<ServiceResponse>>(services);

            return new OperationResult<PaginationResponse<ServiceResponse>>(response);
        }

        public async Task<OperationResult<ServiceResponse>> GetServiceAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            if (service is not null)
            {
                var response = _mapper.Map<ServiceResponse>(service);
                return new OperationResult<ServiceResponse>(response);
            }

            return OperationResult<ServiceResponse>.Fail(OperationCode.EntityWasNotFound, "Услуга не найдена");
        }

        public async Task<OperationResult> UpdateServiceAsync(ServiceRequest request)
        {
            if (await _serviceRepository.GetByIdAsync(request.Id)is null)
                return OperationResult.Fail(OperationCode.EntityWasNotFound, "Услуга не найдена");
            var updatedService = _mapper.Map<Service>(request);

            if(await _serviceRepository.UpdateServiceAsync(updatedService)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }

        public async Task<OperationResult> UpdateCostsServiceAsync(ServiceCostRequest request)
        {
            if (await _serviceRepository.GetByIdAsync(request.Id) is null)
                return OperationResult.Fail(OperationCode.EntityWasNotFound, "Услуга не найдена");
            var updatedService = _mapper.Map<Service>(request);

            if (await _serviceRepository.UpdateCostsServiceAsync(updatedService)) return OperationResult.OK;

            return OperationResult.Fail(OperationCode.ValidationError, "Неверные данные запроса");
        }
    }
}
