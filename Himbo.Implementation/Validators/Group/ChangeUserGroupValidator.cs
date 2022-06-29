using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Group
{
    public class ChangeUserGroupValidator : AbstractValidator<GroupDtoManager>
    {
        private readonly HimboDbContext _context;
        public ChangeUserGroupValidator(HimboDbContext context)
        {
            #region Context
            _context = context;
            #endregion

            #region Validate
            RuleFor(x => x.GroupId.Value)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Group Id is required")
                .NotEmpty().WithMessage("Group Id cannot be empty")
                .Must(x => _context.Groups.Any(g => g.Id == x && g.IsActive))
                .WithMessage("There is no Group with that Id");
            RuleFor(x => x.UserId.Value)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Id is required")
                .NotEmpty().WithMessage("User Id cannot be empty")
                .Must(x => _context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("There is no User with that Id");
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(x => !_context.Users.Any(u => u.Id == x.UserId && u.GroupId == x.GroupId))
                .WithMessage("User is already part of that Group");
            #endregion
        }
    }
}
