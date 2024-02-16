using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
