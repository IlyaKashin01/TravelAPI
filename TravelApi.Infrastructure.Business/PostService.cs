using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Post;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelApi.Infrastructure.Business
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;

        public PostService(IMapper mapper, IImageRepository imageRepository, IFriendRepository friendRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _friendRepository = friendRepository;
            _postRepository = postRepository;
        }

        public async Task<OperationResult<int>> CreatePost(PostRequest request)
        {
            var post = _mapper.Map<Post>(request);
            post.CountLike = 0;
            post.CountDisLike = 0;
            post.CountShare = 0;
            var result = await _postRepository.CreateAsync(post);
            if (request.Files is not null)
                foreach (var file in request.Files)
                {
                    if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                    {
                        var image = new Image();
                        image.Name = file.Name;
                        using (var memory = new MemoryStream())
                        {
                            file.CopyTo(memory);
                            image.Data = memory.ToArray();
                        }
                        image.Post = post;
                        image.PostId = result;
                        await _imageRepository.CreateAsync(image);
                    }
                    else
                    {
                        var stream = file.OpenReadStream();
                        using var fileStream = File.Create($"D:\\studing\\C#\\TravelAPI\\TravelAPI\\{file.FileName}");
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                    }
                }
            return new OperationResult<int>(result);
        }

        public Task<OperationResult> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<IEnumerable<PostResponse>>> GetAllPostsAsync(int id)
        {
            var posts = await _postRepository.GetAllPostsAsync(id);
            var response = _mapper.Map<IEnumerable<PostResponse>>(posts);
            return  new OperationResult<IEnumerable<PostResponse>>(response);
        }

        public async Task<OperationResult<List<IEnumerable<PostResponse>>>> GetAllPostsForFolloversAsync(int id)
        {
            var posts = await _postRepository.GetAllPostsForFollowerAsync(id);
            var response = _mapper.Map<List<IEnumerable<PostResponse>>>(posts);
            return new OperationResult<List<IEnumerable<PostResponse>>>(response);
        }

        public Task<OperationResult> UpdatePost(PostRequest request)
        {
            throw new NotImplementedException();
        } 
    }
}
