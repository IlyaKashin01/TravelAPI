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
    public class PersonFileRepository : BaseRepository<PersonFile>, IPersonFIleRepository
    {
        public PersonFileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PersonFile>> GetAllFilesByStorageIdAsync ( int storageId)
        {
            return await _context.PersonFiles.Where(x => x.StrorageId == storageId).ToListAsync();
        }
    }
}
