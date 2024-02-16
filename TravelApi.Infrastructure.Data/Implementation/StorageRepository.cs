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
    public class StorageRepository : BaseRepository<Storage>, IStorageRepository
    {
        public StorageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Storage?> GetAllFilesAsync(int storageId, int personId)
        {
            return await _context.Storage.FirstOrDefaultAsync(x => x.Id == storageId);
        }

        public async Task<int> UpdateStorageAsync(Storage storage)
        {
            var updateStorage = await GetByIdAsync(storage.Id);

            if (updateStorage == null) return 0;

            foreach (var person in storage.Persons) updateStorage.Persons.Add(person);
            updateStorage.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return updateStorage.Id;
        }
    }
}
