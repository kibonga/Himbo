using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Category
{
    public class UpdateCategoryValidator: AbstractValidator<CategoryDto>
    {
        private readonly HimboDbContext _context;

        public UpdateCategoryValidator(HimboDbContext context)
        {
            #region DbContext
            this._context = context;
            #endregion

            #region Update Category specific validation
            RuleFor(dto => dto)
                .Cascade(CascadeMode.Stop)
                .Must(dto => dto.ParentId != dto.Id)
                .When(dto => dto.ParentId.HasValue).WithMessage("Parent Category Id can't be same as Category Id");
            #endregion

            #region Include
            Include(new ICategoryValidator(_context));
            Include(new MetaValidator()); // Meta validator doesn't require connection
            Include(new TitleValidator<Domain.Entities.Category>(_context));
            #endregion

            #region Can't change Parent Category Id if Category has children
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(id => !_context.Categories.FirstOrDefault(c => c.Id == id).Children.Any())
                .WithMessage("Can't change Parent category if it contains Child Categories");
            #endregion


        }
    }
}
