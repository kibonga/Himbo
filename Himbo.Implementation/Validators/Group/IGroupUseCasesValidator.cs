using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Group
{
    public class IGroupUseCasesValidator : AbstractValidator<GroupUseCasesIdsDto>
    {
        private readonly HimboDbContext _context;
        public IGroupUseCasesValidator(HimboDbContext context)
        {
            #region Context
            _context = context;
            #endregion

            #region Validate
            #region Validate
            RuleFor(x => x.Id.Value)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Group Id is required")
                .NotEmpty().WithMessage("Group Id cannot be empty")
                .Must(x => _context.Groups.Any(g => g.Id == x && g.IsActive))
                .WithMessage("Cannot find Group with that Id.");
            RuleFor(x => x.UseCasesIds)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("UseCases Ids are required")
                .NotEmpty().WithMessage("UseCases Ids Id cannot be empty")
                .Must(x => x.Count() > 0)
                .WithMessage("Minimum number of use case Ids is 1.")
                .Must(ids =>
                {
                    if (ids == null)
                    {
                        return true;
                    }

                    return ids.Distinct().Count() == ids.Count();
                })
                .WithMessage("Duplicate use case Ids are not allowed.")
                .Must(CheckIdsAreValid).WithMessage("Invalid Ids were passed");
            #endregion
            #endregion
        }

        private bool CheckIdsAreValid(IEnumerable<int> ids)
        {
            var validIds = _context.UseCases.Where(u => u.IsActive).Select(u => u.Id).ToList();
            return ids.All(id => validIds.Contains(id));
        }
    }
}
