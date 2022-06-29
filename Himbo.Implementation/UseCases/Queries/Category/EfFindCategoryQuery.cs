using AutoMapper;
using Himbo.Application.Exceptions;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.Queries.Category;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.Category
{
    public class EfFindCategoryQuery: EfUseCase, IFindCategoryQuery
    {
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 14;
        public string Name => "Query single Category (EF)";
        public string Description => "Use case for querying single Category using EF";
        #endregion

        public EfFindCategoryQuery
        (
            HimboDbContext context,
            IMapper mapper
        ) : base(context)
        {
            _mapper = mapper;
        }

        public CategoryDto Execute(int search)
        {
            #region Check if exists
            var category = Context.GetCategoryByIdAndThrow(search);
            #endregion

            #region Map Category
            var dto = _mapper.Map<CategoryDto>(category);
            #endregion

            #region Return Dto
            return dto; 
            #endregion
        }
    }
}
