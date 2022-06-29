using AutoMapper;
using Himbo.Application.UseCases;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.Application.UseCases.Queries.Tag;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Tag
{
    public class EfGetTagsQuery : EfUseCase, IGetTagsQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 5;
        public string Name => "Query all Tags (EF)";
        public string Description => "Use case for querying all Tags using EF";
        #endregion

        public EfGetTagsQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<TagDtoBase> Execute(BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Tags.AsQueryable();
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
            //var response = query.GetPagedResponse(search, toSkip, x => _mapper.Map<TagDtoBase>(x));
            var response = query.GetPagedResponse<TagDtoBase>(search, _mapper);
            #endregion

            #region Return Response
            return response; 
            #endregion
        }

    }
}
