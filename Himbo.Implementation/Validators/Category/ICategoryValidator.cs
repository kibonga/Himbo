using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Category
{
    public class ICategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly HimboDbContext _context;
        public ICategoryValidator(HimboDbContext context)
        {
            #region DbContext
            this._context = context;
            #endregion

            #region Check Parent Category
            RuleFor(x => x.ParentId)
                .Must(x => _context.Categories.Any(c => c.Id == x && c.IsActive))
                .When(dto => dto.ParentId.HasValue).WithMessage("Parent category does not exist.");
                //.Must(GreaterThanZero).WithMessage("Property {PropertyName} is not valid").When(x => x.Id > 0)
                //.Must(IsParentCategoryValid).WithMessage("Property {PropertyName} is not valid").When(x => x.ParentId > 0);
            #endregion
        }

        private bool GreaterThanZero(int parentId)
        {
            return parentId > 0;
        }

        private bool IsParentCategoryValid(int parentId)
        {
            return _context.Categories.Any(x => x.Id == parentId && x.IsActive);
        }
    }
}
