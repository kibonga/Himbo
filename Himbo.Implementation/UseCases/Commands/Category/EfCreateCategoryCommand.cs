using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Category;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Extensions.Common;
using Himbo.Implementation.Validators.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Category
{
    public class EfCreateCategoryCommand: EfUseCase, ICreateCategoryCommand
    {
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 9;
        public string Name => "Create Category (EF)";
        public string Description => "Use case for creating new Category using EF";
        #endregion

        public EfCreateCategoryCommand
        (
            HimboDbContext context,
            CreateCategoryValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(CategoryDto request)
        {
            #region Validate Tag
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Category
            var category = _mapper.Map<Domain.Entities.Category>(request);
            #endregion

            #region Add Image
            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                category.AddImage(request.ImageFileName, _mapper);
            }
            #endregion

            #region Create and Save
            Context.AddEntity(category);
            #endregion
        }
    }
}
