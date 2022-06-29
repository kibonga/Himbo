using AutoMapper;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Group;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Group
{
    public class EfGetGroupsQuery: EfUseCase, IGetGroupsQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 40;
        public string Name => "Query all Groups (EF)";
        public string Description => "Use case for querying all Groups using EF";
        #endregion

        public EfGetGroupsQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<GroupDtoBase> Execute(BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Groups.AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            #region Create Response
            var response = query.GetPagedResponse<GroupDtoBase>(search, _mapper);
            #endregion

            #region Return Response
            return response;
            #endregion
        }
    }
}
