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
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Image>> GetAllImages(int id)
        {
            return await _context.Images.Where(r => r.PostId == id).ToListAsync();
        }

        public async Task<Image?> GetByName(string name)
        {
            return await _context.Images.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Image>> GetAllImagesByStorageIdAsync(int storageId)
        {
            return await _context.Images.Where(x => x.StorageId == storageId).ToListAsync(); 
        }
    }
}
