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
    public class EfUpdateCategoryCommand: EfUseCase, IUpdateCategoryCommand
    {
        private readonly UpdateCategoryValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 10;
        public string Name => "Update Category (EF)";
        public string Description => "Use case for updating existing Category using EF";
        #endregion

        public EfUpdateCategoryCommand
        (
            HimboDbContext context,
            UpdateCategoryValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(CategoryDto request)
        {
            #region Get Category by Id
            var category = Context.GetByIdAndThrow<Domain.Entities.Category>(request.Id.Value);
            #endregion

            #region Validate Tag
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Category
            _mapper.Map(request, category);
            #endregion

            #region Add Image
            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                category.AddImage(request.ImageFileName, _mapper);
            }
            #endregion

            #region Update Category
            Context.UpdateEntity(category);
            #endregion
        }
    }
}
