using AutoMapper;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Group;
using Himbo.Application.UseCases.Queries.Responses;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Group
{
    public class EfFindGroupQuery: EfUseCase, IFindGroupQuery
    {
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 41;
        public string Name => "Query single Group (EF)";
        public string Description => "Use case for querying single Group using EF";
        #endregion

        public EfFindGroupQuery
        (
            HimboDbContext context,
            IMapper mapper
        ) : base(context)
        {
            _mapper = mapper;
        }

        public GroupDtoInfoBase Execute(int id)
        {
            #region Get Group by Id
            var group = Context.GetGroupByIdAndThrow(id);
            #endregion

            #region Map Group
            var dto = _mapper.Map<GroupDtoInfoBase>(group);
            #endregion

            #region Group Info
            dto.NumberOfUsers = group?.Users.Count() ?? 0;
            dto.NumberOfUseCases = group?.UseCases.Count() ?? 0;
            #endregion

            #region Return Dto
            return dto;
            #endregion
        }
    }
}
