using AutoMapper;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Common
{
    public static class PaginationExtensions
    {

        public static PagedResponse<TDto> GetPagedResponse<TDto>(this IQueryable<object> query, PagedSearch search, IMapper mapper)
            where TDto : class
        {
            var perPage = search.GetPerPage();
            var toSkip = search.GetPagesToSkip();

            var response = new PagedResponse<TDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page.Value,
                ItemsPerPage = search.PerPage.Value,
                Data = query.Skip(toSkip).Take(perPage).Select(x => mapper.Map<TDto>(x)).ToList()
            };

            return response;
        }
        public static PagedResponse<TDto> GetPagedResponse2<TDto>(this IQueryable<object> query, PagedSearch search, IMapper mapper)
            where TDto : class
        {
            var perPage = search.GetPerPage();
            var toSkip = search.GetPagesToSkip();

            var response = new PagedResponse<TDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page.Value,
                ItemsPerPage = search.PerPage.Value,
                Data = query.Skip(toSkip).Take(perPage).Select(x => mapper.Map<TDto>(x)).ToList()
            };

            return response;
        }

        #region Legacy Code
        /*        
        public static PagedResponse<T> GetPagedResponse<T, TQuery>(this IQueryable<TQuery> query, BasePagedSearch search, int toSkip, Expression<Func<TQuery, T>> predicate = null)
            where T: class, new()
            where TQuery: class, new()
        {
            var response = new PagedResponse<T>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page.Value,
                ItemsPerPage = search.PerPage.Value,

                Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(predicate).ToList()
            };

            return response;
        }*/
        #region Utils
        /*        
        private static PagedSearch GetPaginationInfo(this PagedSearch search)
        {
            if (search.PerPage == null || search.PerPage < MIN_PER_PAGE)
            {
                search.PerPage = PER_PAGE;
            }

            if (search.Page == null || search.Page < DEFAULT_PAGE)
            {
                search.PerPage = DEFAULT_PAGE;
            }

            return search;
        }
        private static int GetNumberOfPagesToSkip(this PagedSearch search)
        {
            return (search.Page.Value - 1) * search.PerPage.Value;
        } */
        #endregion
        #endregion
    }
}
