using AutoMapper;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Entities;
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
    public class EfGetGroupUsersQuery: EfUseCase, IGetGroupUsersQuery
    {
        private readonly IMapper _mapper;
        #region UsesCase Data
        public int Id => 50;
        public string Name => "Query all Group Users (EF)";
        public string Description => "Use case for querying all Users for single Group using EF";
        #endregion

        public EfGetGroupUsersQuery(HimboDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public PagedResponse<UserDtoBase> Execute(int id, BasePagedSearch search)
        {
            #region Create Queryable
            var query = Context.Users
                .Include(x => x.Group)
                .Where(x => x.GroupId == id && x.IsActive)
                .AsQueryable();
            #endregion

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword));
            }

            #region Create Response
            var response = query.GetPagedResponse<UserDtoBase>(search, _mapper);
            #endregion

            #region Return Response
            return response;
            #endregion
        }
    }
}
