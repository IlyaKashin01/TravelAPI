using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IImageRepository: IBaseRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllImages(int id);
        Task<Image?> GetByName(string name);
        Task<IEnumerable<Image>> GetAllImagesByStorageIdAsync(int storageId);
    }
}
