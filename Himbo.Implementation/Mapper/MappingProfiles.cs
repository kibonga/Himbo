using AutoMapper;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Domain;
using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Maps
            //Tag
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagDtoBase>().ReverseMap();
            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDtoBase>().ReverseMap();
            // Post
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostDtoDetails>().ReverseMap();
            CreateMap<Post, PostDtoBase>().ReverseMap();
            // User
            CreateMap<User, AuthorDtoBase>().ReverseMap();
            CreateMap<User, UserDtoBase>().ReverseMap();
            // Comment
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentDtoDetails>().ReverseMap();
            CreateMap<Comment, CommentDtoUpdate>().ReverseMap();
            // Like
            // Rating
            CreateMap<Rating, RatingDto>().ReverseMap();
            // Image
            CreateMap<Image, ImageDto>().ReverseMap();
            // Group
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Group, GroupDtoBase>().ReverseMap();
            CreateMap<Group, GroupDtoDetails>().ReverseMap();
            CreateMap<Group, GroupDtoInfoBase>().ReverseMap();
            CreateMap<Group, GroupDtoInfo>().ReverseMap();
            // UseCase
            CreateMap<UseCase, UseCaseDto>().ReverseMap();
            CreateMap<UseCase, UseCaseDtoDetails>().ReverseMap();
            #endregion
        }
    }
}
