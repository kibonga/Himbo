using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Queries.Responses
{
    public class PagedResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        public IEnumerable<T> Data { get; set; }
    }

    public class PagedResponseWithLikes<T>: PagedResponse<T>
        where T: class
    {
        public int NumberOfLikes { get; set; }
    }
}
