using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IPersonFIleRepository: IBaseRepository<PersonFile>
    {
        Task<IEnumerable<PersonFile>> GetAllFilesByStorageIdAsync(int storageId);
    }
}
