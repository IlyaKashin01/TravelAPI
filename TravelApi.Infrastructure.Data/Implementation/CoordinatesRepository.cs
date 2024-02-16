using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class CoordinatesRepository : BaseRepository<Coordinates>, ICoordinatesRepository
    {
        public CoordinatesRepository(AppDbContext context): base(context) { }

        public async Task<IEnumerable<Coordinates>> GetAllCoordinatesAsync(int id)
        {
            return await _context.Coordinates.Where(r => r.JourneyId == id).ToListAsync();
        }

        public async Task<Coordinates?> GetByJourneyIdAsync(int id, double latitube, double longitude)
        {
            return await _context.Coordinates.FirstOrDefaultAsync(r => r.JourneyId == id && r.Latitube == latitube && r.Longitude == longitude);
        }

        public async Task<bool> UpdateCoordinatesAsync(Coordinates coordinates)
        {
            var updatedCoordinates = await GetByJourneyIdAsync(coordinates.Id, coordinates.Latitube, coordinates.Longitude);

            if (updatedCoordinates is null) return false;

            updatedCoordinates.Latitube = coordinates.Latitube;
            updatedCoordinates.Longitude = coordinates.Longitude;
            updatedCoordinates.JourneyId = coordinates.JourneyId;
            updatedCoordinates.Journey = coordinates.Journey;
            updatedCoordinates.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
