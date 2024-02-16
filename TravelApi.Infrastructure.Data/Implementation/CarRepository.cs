using Microsoft.EntityFrameworkCore;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context) { }

        public async Task<bool> CheckExistCarAsync(int personId)
        {
            var car = await _context.Cars.Where(x => x.Person.Id == personId).FirstOrDefaultAsync();
            if (car is not null) return true;
            return false;
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            var updatedCar = await GetByIdAsync(car.Id);

            if (updatedCar == null) return false;

            updatedCar.Brand = car.Brand;
            updatedCar.Expenditure = car.Expenditure;
            updatedCar.Number= car.Number;
            updatedCar.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
