using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;

namespace TravelApi.Infrastructure.Data.Implementation
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Post>> GetAllPostsAsync(int id)
        {
            return await _context.Posts.Where(r => r.PersonId == id).ToListAsync();
        }

        public async Task<List<IEnumerable<Post>>> GetAllPostsForFollowerAsync(int id)
        {
            var friends = await _context.Friends.Where(r => r.PersonOne == id).Where(r => r.PersonTwo == id).ToListAsync();
            List<IEnumerable<Post>> posts = new List<IEnumerable<Post>>();
            foreach (var friend in friends)
                posts.Add(await _context.Posts.Where(r => r.PersonId == id).ToListAsync());
            return posts;
        }

        public async Task<Post?> GetByNamePostAsync(string name)
        {
            return await _context.Posts.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var updatedPost = await GetByIdAsync(post.Id);
            if (updatedPost is null) return false;
            updatedPost.Name = post.Name;
            updatedPost.Description = post.Description;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
