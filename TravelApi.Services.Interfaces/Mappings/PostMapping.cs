using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;
using TravelApi.Services.Interfaces.DTO.Post;

namespace TravelApi.Services.Interfaces.Mappings
{
    public class PostMapping: Profile
    {
        public PostMapping()
        {
            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostResponse>();
        }
    }
}
