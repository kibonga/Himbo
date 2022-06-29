using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.UseCase
{
    public class IForbiddenAdditionalUseCaseValidator : AbstractValidator<UseCaseDtoManager>
    {
        private readonly HimboDbContext _context;
        public IForbiddenAdditionalUseCaseValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validate
            RuleFor(x => x.UserId.Value)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Id is required")
                .Must(x => _context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("Cannot find User with that Id");
            RuleFor(x => x.UseCaseIds)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("UseCase Ids are required")
                .NotEmpty().WithMessage("UseCase Ids cannot be empty")
                .Must(ids =>
                {
                    if (ids == null)
                    {
                        return true;
                    }
                    return ids.Distinct().Count() == ids.Count();
                }).WithMessage("Duplicate UseCase Ids are not allowed")
                .Must(CheckIdsAreValid).WithMessage("Invalid Ids were passed");
            #endregion
        }

        private bool CheckIdsAreValid(IEnumerable<int> ids)
        {
            var validIds = _context.UseCases.Where(uc => uc.IsActive).Select(uc => uc.Id).ToList();
            return ids.All(id => validIds.Contains(id));
        }
    }
}
