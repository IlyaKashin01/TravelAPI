using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Post;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IPostService
    {
        Task<OperationResult<int>> CreatePost(PostRequest request);
        Task<OperationResult> DeletePost(int id);
        Task<OperationResult> UpdatePost(PostRequest request);
        Task<OperationResult<IEnumerable<PostResponse>>> GetAllPostsAsync(int id);
        Task<OperationResult<List<IEnumerable<PostResponse>>>> GetAllPostsForFolloversAsync(int id);
    }
}
