using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.UseCase
{
    internal class IUseCaseValidator : AbstractValidator<UseCaseDto>
    {
        private readonly HimboDbContext _context;
        public IUseCaseValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validation
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(100).WithMessage("Maximum number of characters is 100");
            #endregion

            #region Validate
            Include(new NameValidator<Domain.UseCase>(_context));
            #endregion
        }
    }
}
