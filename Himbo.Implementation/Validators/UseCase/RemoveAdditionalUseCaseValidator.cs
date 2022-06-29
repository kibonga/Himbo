using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.UseCase
{
    public class RemoveAdditionalUseCaseValidator : AbstractValidator<UseCaseDtoManager>
    {
        private readonly HimboDbContext _context;
        public RemoveAdditionalUseCaseValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new IForbiddenAdditionalUseCaseValidator(_context));
            #endregion

            #region Validate
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(CheckIdsAreDefined).WithMessage("Cannot remove UseCase Ids that aren't defined");
            #endregion
        }

        private bool CheckIdsAreDefined(UseCaseDtoManager dto)
        {
            var useCases = _context.UseCases.Include(x => x.UsersAdditionalUseCases).Where(uc => uc.UsersAdditionalUseCases.Any(u => u.Id == dto.UserId)).ToList();
            return useCases.Any(uc => dto.UseCaseIds.Contains(uc.Id));
        }
    }
}
