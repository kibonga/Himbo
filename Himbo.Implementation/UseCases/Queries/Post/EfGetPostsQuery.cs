using AutoMapper;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Post;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Post
{
    public class EfGetPostsQuery: EfUseCase, IGetPostsQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 21;
        public string Name => "Query all Posts (EF)";
        public string Description => "Use case for querying all Posts using EF";
        #endregion

        public EfGetPostsQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<PostDtoBase> Execute(BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Posts
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword));
            }

            #region Paginate
            /*search = search.GetPaginationInfo<BasePagedSearch>();
            var toSkip = search.GetNumberOfPagesToSkip();*/
            #endregion

            #region Create Response
            //var response = query.GetPagedResponse(search, toSkip, x => _mapper.Map<PostDtoBase>(x));
            var response = query.GetPagedResponse<PostDtoBase>(search, _mapper);
            #endregion

            #region Return Response
            return response;
            #endregion
        }
    }
}
