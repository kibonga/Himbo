using AutoMapper;
using Himbo.Application.Exceptions;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.Queries.Tag;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Tag
{
    public class EfFindTagQuery: EfUseCase, IFindTagQuery
    {
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 6;
        public string Name => "Query single Tag (EF)";
        public string Description => "Use case for querying single Tag using EF";
        #endregion

        public EfFindTagQuery
        (
            HimboDbContext context,
            IMapper mapper
        ) : base(context)
        {
            _mapper = mapper;
        }

        public TagDto Execute(int search)
        {
            #region Check if exists
            var tag = Context.GetByIdAndThrow<Domain.Entities.Tag>(search);
            #endregion

            #region Map Tag
            var dto = _mapper.Map<TagDto>(tag);
            #endregion

            #region Return dto
            return dto; 
            #endregion
        }
    }
}
