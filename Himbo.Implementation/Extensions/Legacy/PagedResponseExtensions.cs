using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Legacy
{
    public static class PagedResponseExtensions
    {
        /*      public static PagedResponse<T> GetPagedResponse<T, TQuery>(this PagedResponse<T> response, IQueryable<TQuery> query, BasePagedSearch search, int toSkip, Expression<Func<TQuery, T>> predicate = null)
                  where T : class, new()
                  where TQuery: class, new ()
              {
                  response.TotalCount = query.Count();
                  response.CurrentPage = search.Page.Value;
                  response.ItemsPerPage = search.PerPage.Value;

                  response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(predicate).ToList() as IEnumerable<T>;

                  return response;
              }*/
    }
}
