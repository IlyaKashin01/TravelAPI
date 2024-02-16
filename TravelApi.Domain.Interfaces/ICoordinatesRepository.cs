using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface ICoordinatesRepository: IBaseRepository<Coordinates>
    {
        Task<IEnumerable<Coordinates>> GetAllCoordinatesAsync(int id);
        Task<Coordinates?> GetByJourneyIdAsync(int id, double latitube, double longitude);

        Task<bool> UpdateCoordinatesAsync(Coordinates coordinates);
    }
}
