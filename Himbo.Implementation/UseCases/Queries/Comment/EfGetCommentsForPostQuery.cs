using AutoMapper;
using Himbo.Application.UseCases;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Comment;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Comment
{
    public class EfGetCommentsForPostQuery: EfUseCase, IGetCommentsQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 28;
        public string Name => "Query all Comments for Post (EF)";
        public string Description => "Use case for querying all Comments for  single Post using EF";
        #endregion

        public EfGetCommentsForPostQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<CommentDtoDetails> Execute(int id, BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Comments
                .Include(x => x.User)
                .Include(x => x.UsersWhoLiked.Where(u => u.IsActive))
                .Where(x => x.PostId == id && x.Post.IsActive && x.IsActive)
                .AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Content.Contains(search.Keyword));
            }

            #region Create Response
            var response = query.GetPagedResponse<CommentDtoDetails>(search, _mapper);
            #endregion

            #region Return Response
            return response;
            #endregion
        }

        private bool CheckIfParentIsActive(Domain.Entities.Comment comment)
        {
            if(comment.Parent != null)
            {
                return CheckIfParentIsActive(comment.Parent);
            }
            else
            {
                return comment.Parent.IsActive;
            }
        }
    }
}
