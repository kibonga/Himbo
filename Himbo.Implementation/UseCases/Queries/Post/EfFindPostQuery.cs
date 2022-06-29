using AutoMapper;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.Queries.Post;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Post
{
    public class EfFindPostQuery: EfUseCase, IFindPostQuery
    {
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 22;
        public string Name => "Query single Post (EF)";
        public string Description => "Use case for querying single Post using EF";
        #endregion

        public EfFindPostQuery
        (
            HimboDbContext context,
            IMapper mapper
        ) : base(context)
        {
            _mapper = mapper;
        }

        public PostDtoDetails Execute(int search)
        {
            #region Get Post by Id
            var post = Context.GetPostByIdAndThrow(search);
            #endregion

            #region Map Post
            var dto = _mapper.Map<PostDtoDetails>(post);
            dto.NumberOfLikes = dto.UsersWhoLiked?.Count() ?? 0;
            dto.NumberOfComments = dto.Comments?.Count() ?? 0;
            if(post.Ratings.Any())
            {
                dto.AverageRating = (float)post.Ratings.Average(x => x.NumberOfStars);
            }
            #endregion

            #region Return Dto
            return dto;
            #endregion
        }
    }
}
