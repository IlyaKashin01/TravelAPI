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
    public class JourneyRepository : BaseRepository<Journey>, IJourneyRepository
    {
        public JourneyRepository(AppDbContext context) : base(context) { }

        public async Task<PaginationResponse<Journey>> GetAllJourneyAsync(PaginationRequest paginationRequest)
        {
            var query = _context.Journeys.AsQueryable();

            if (paginationRequest.searchIntValue is not null)
                query = _context.Users.Where(x => x.Id == paginationRequest.searchIntValue).SelectMany(x => x.Journeys).Select(x => x.Journey).AsQueryable()!;

            var totalCount = await query.CountAsync();
            query = query.Skip(paginationRequest.Skip).Take(paginationRequest.Take);

            return new PaginationResponse<Journey>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount
            };
        }

        public async Task<Journey?> GetJourneyByNameAsync(string name)
        {
            return await _context.Journeys.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<bool> UpdateJourneyAsync(Journey journey)
        {
            var updatedJourney = await GetByIdAsync(journey.Id);

            if(updatedJourney == null) return false;

            updatedJourney.UpdatedDate = DateTime.Now;
            updatedJourney.Name = journey.Name;
            updatedJourney.Description = journey.Description;
            updatedJourney.DateStart = journey.DateStart;
            updatedJourney.DateEnd = journey.DateEnd;
            updatedJourney.CategoryId = journey.CategoryId;
            updatedJourney.Coordinates = journey.Coordinates;
            updatedJourney.Services = journey.Services;
            updatedJourney.Users = journey.Users;
            updatedJourney.CountDays = journey.CountDays;
            updatedJourney.CountPerson = journey.CountPerson;
            updatedJourney.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCostsJourneyAsync(int journeyId)
        {
            var updatedJourney = await GetByIdAsync(journeyId);

            if (updatedJourney == null) return false;
            updatedJourney.ExpectedCost = await _context.Services.SumAsync(x => x.ExpectedCost);
            updatedJourney.ActualCost = await _context.Services.SumAsync(x => x.ActualCost);
            updatedJourney.ProjectedCost = updatedJourney.ActualCost * (updatedJourney.ExpectedCost / updatedJourney.ActualCost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
