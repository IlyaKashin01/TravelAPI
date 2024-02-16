using Microsoft.AspNetCore.Mvc;
using TravelApi.Common;
using TravelApi.Common.OperationResult;
using TravelApi.Common.Pagination;
using TravelApi.Domain.Core.Entities;
using TravelApi.Infrastructure.Business;
using TravelApi.Services.Interfaces.DTO.Post;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class PostController: ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("getAllPosts")]
        public async Task<ActionResult<OperationResult<IEnumerable<PostResponse>>>> GetAllPosts(int id)
        {
            var response = await _postService.GetAllPostsAsync(id);
            return Ok(response);
        }

        [HttpGet("getAllPostsForFollower")]
        public async Task<ActionResult<OperationResult<IEnumerable<PostResponse>>>> GetAllPostsForFollowers(int id)
        {
            var response = await _postService.GetAllPostsForFolloversAsync(id);
            return Ok(response);
        }

        [HttpPost("createPost")]
        public async Task<ActionResult<OperationResult<int>>> CreatePost(PostRequest request, IFormFileCollection files)
        {
            var response = await _postService.CreatePost(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("updatePost")]
        public async Task<ActionResult<OperationResult>> UpdatePost(PostRequest request)
        {
            var response = await _postService.UpdatePost(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("deletePost")]
        public async Task<ActionResult<OperatingSystem>> DeletePost(int id)
        {
            var response = await _postService.DeletePost(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
