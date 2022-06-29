/*using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Legacy
{
    public static class PaginationExtensions
    {
        private static int PER_PAGE => 15;
        private static int MIN_PER_PAGE => 1;
        private static int DEFAULT_PAGE => 1;

        public static PagedSearch GetPaginationInfo<T>(this PagedSearch search)
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





        public static int GetNumberOfPagesToSkip(this BasePagedSearch search)
        {
            return (search.Page.Value - 1) * search.PerPage.Value;
        }
    }
}
*/