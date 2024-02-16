using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Service;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context) { }

        public async Task<PaginationResponse<Service>> GetAllServicesAsync(PaginationRequest pagination)
        {
            var query = _context.Services.AsQueryable();

            if (pagination.searchIntValue is not null)
                query = query.Where(r => r.JourneyId == pagination.searchIntValue);

            var totalCount = await query.CountAsync();
            query = query.Skip(pagination.Skip).Take(pagination.Take);

            return new PaginationResponse<Service>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount
            };
            throw new Exception();
        }

        public async Task<Service?> GetServiceByNameAsync(string name)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Name == name);
        }
        
        public async Task<bool> UpdateServiceAsync(Service service)
        {
            var updatedService = await GetByIdAsync(service.Id);

            if (updatedService is null) return false;

            updatedService.Name = service.Name;
            updatedService.Description = service.Description;
            updatedService.ExpectedCost = service.ExpectedCost;
            updatedService.ActualCost = service.ActualCost;
            updatedService.ProjectedCost = service.ProjectedCost;
            updatedService.JourneyId = service.JourneyId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCostsServiceAsync(Service service)
        {
            var updatedService = await GetByIdAsync(service.Id);
            if (updatedService is null) return false;
            updatedService.ActualCost = service.ActualCost;
            updatedService.ProjectedCost = service.ActualCost * (updatedService.ExpectedCost / service.ActualCost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
