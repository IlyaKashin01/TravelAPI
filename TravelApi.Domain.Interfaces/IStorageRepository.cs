using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IStorageRepository: IBaseRepository<Storage>
    {
        Task<Storage?> GetAllFilesAsync(int storageId, int personId);
        Task<int> UpdateStorageAsync(Storage storage);
    }
}
