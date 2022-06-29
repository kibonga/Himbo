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
    public class RemoveGroupUseCasesValidator : AbstractValidator<GroupUseCasesIdsDto>
    {
        private readonly HimboDbContext _context;
        public RemoveGroupUseCasesValidator(HimboDbContext context)
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
                .Must(CheckIdsAreDefined).WithMessage("Cannot remove UseCase Ids that are not defined");
            #endregion
        }

        private bool CheckIdsAreDefined(GroupUseCasesIdsDto dto)
        {
            //return !_context.Groups.Include(x => x.UseCases).Where(x => x.Id == dto.Id).Any(x => dto.UseCasesIds.Contains(x.Id));
            //return !_context.Groups.Include(x => x.UseCases).Any(g => g.Id == dto.Id);
            var group = _context.Groups.Include(x => x.UseCases).FirstOrDefault(x => x.Id == dto.Id);

            return group.UseCases.Any(uc => dto.UseCasesIds.Contains(uc.Id));
        }
    }
}
