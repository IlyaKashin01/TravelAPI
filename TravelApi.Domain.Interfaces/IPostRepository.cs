using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Domain.Interfaces
{
    public interface IPostRepository: IBaseRepository<Post> 
    {
        //Task<PaginationResponse<Post>> GetAllPostsAsync(PaginationRequest pagination);
        Task<IEnumerable<Post>> GetAllPostsAsync(int id);
        Task<List<IEnumerable<Post>>> GetAllPostsForFollowerAsync(int id);
        Task<Post?> GetByNamePostAsync(string name);
        Task<bool> UpdatePostAsync(Post post);
    }
}
