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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly HimboDbContext _context;

        public CreateCategoryValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Create Category specific validation
            #endregion

            #region Include
            Include(new ICategoryValidator(_context));
            Include(new MetaValidator()); // Meta validator doesn't require connection
            Include(new TitleValidator<Domain.Entities.Category>(_context));
            #endregion
        }

    }
}
