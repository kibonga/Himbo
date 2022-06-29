using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Like
{
    internal class ILikeValidator : AbstractValidator<LikeDtoCommon>
    {
        private readonly HimboDbContext _context;
        public ILikeValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            RuleFor(x => x.UsersWhoLikedId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Id is required")
                .Must(x => _context.Users.Any(u => u.Id == x.Value && u.IsActive))
                .WithMessage("Invalid User Id.");
        }
    }
}
