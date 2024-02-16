using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface ICarRepository: IBaseRepository<Car>
    {
        Task<bool> CheckExistCarAsync(int personId);
        Task<bool> UpdateCarAsync(Car car);
    }
}
