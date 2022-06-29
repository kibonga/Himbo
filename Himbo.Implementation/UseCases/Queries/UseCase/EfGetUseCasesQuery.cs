using AutoMapper;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.Application.UseCases.Queries.UseCase;
using Himbo.DataAccess;
using Himbo.Implementation.Extensions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.UseCase
{
    public class EfGetUseCasesQuery: EfUseCase, IGetUseCasesQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 43;
        public string Name => "Query all UseCases for Group (EF)";
        public string Description => "Use case for querying all UseCases for single Group using EF";
        #endregion

        public EfGetUseCasesQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<UseCaseDtoDetails> Execute(int id, BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.UseCases
                .Include(x => x.Groups)
                .Where(x => x.Groups.Any(x => x.Id == id))
                .AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            #region Create Response
            var response = query.GetPagedResponse<UseCaseDtoDetails>(search, _mapper);
            #endregion

            #region Return Response
            return response;
            #endregion
        }
    }
}
