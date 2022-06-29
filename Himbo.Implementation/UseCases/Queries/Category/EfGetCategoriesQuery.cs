using AutoMapper;
using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Category;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Category
{
    public class EfGetCategoriesQuery: EfUseCase, IGetCategoriesQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 13;
        public string Name => "Query all Categories (EF)";
        public string Description => "Use case for querying all Categories using EF";
        #endregion

        public EfGetCategoriesQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<CategoryDtoBase> Execute(BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Categories.Include(x => x.Image).AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword));
            }

            #region Paginate
            //search = search.GetPaginationInfo<BasePagedSearch>();
            //search = search.GetPaginationInfo<BasePagedSearch>();
            //var toSkip = search.GetNumberOfPagesToSkip();
            #endregion

            #region Create Response
            //var response = query.GetPagedResponse(search, toSkip, x => _mapper.Map<CategoryDtoBase>(x));
            var response = query.GetPagedResponse<CategoryDtoBase>(search, _mapper);
            #endregion

            #region Return Response
            return response; 
            #endregion
        }
    }
}
