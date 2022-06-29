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
    public class AddGroupUseCasesValidator : AbstractValidator<GroupUseCasesIdsDto>
    {
        private readonly HimboDbContext _context;
        public AddGroupUseCasesValidator(HimboDbContext context)
        {
            #region Context
            _context = context;
            #endregion

            #region Include
            Include(new IGroupUseCasesValidator(_context));
            #endregion

            #region Validate
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(CheckIdsAreDefined).WithMessage("Cannot add UseCase Ids that are already defined");
            #endregion
        }

        private bool CheckIdsAreDefined(GroupUseCasesIdsDto dto)
        {
            var group = _context.Groups.Include(x => x.UseCases).FirstOrDefault(x => x.Id == dto.Id);

            return !group.UseCases.Any(uc => dto.UseCasesIds.Contains(uc.Id));
        }
    }
}
