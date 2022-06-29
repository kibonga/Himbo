using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Searches
{
    public class BaseSearch
    {
        public string Keyword { get; set; }
    }

    public class PagedSearch
    {
        #region Static
        private static int PER_PAGE => 15;
        private static int MIN_PER_PAGE => 1;
        private static int DEFAULT_PAGE => 1; 
        #endregion

        public int? PerPage { get; set; } = PER_PAGE;
        public int? Page { get; set; } = DEFAULT_PAGE;

        #region Getters
        public int GetPerPage()
        {
            if (PerPage == null || PerPage < MIN_PER_PAGE)
            {
                PerPage = PER_PAGE;
            }

            if (Page == null || Page < DEFAULT_PAGE)
            {
                PerPage = DEFAULT_PAGE;
            }

            return PerPage.Value;
        }

        public int GetPagesToSkip()
        {
            return (Page.Value - 1) * PerPage.Value;
        } 
        #endregion

    }

    public class BasePagedSearch: PagedSearch
    {
        public string Keyword { get; set; }
    }
}
