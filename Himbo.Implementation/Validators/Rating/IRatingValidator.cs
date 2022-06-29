using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Rating
{
    public class IRatingValidator: AbstractValidator<RatingDto>
    {
        private readonly HimboDbContext _context;
        public IRatingValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validation
            RuleFor(x => x.UserId.Value)
                .NotNull().WithMessage("User Id is required")
                .Must(x => _context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("Invalid User Id");
            RuleFor(x => x.PostId.Value)
                .NotNull().WithMessage("Post Id is required")
                .Must(x => _context.Posts.Any(p => p.Id == x && p.IsActive))
                .WithMessage("Invalid Post Id");
            RuleFor(x => x.NumberOfStars.Value)
                .NotNull().WithMessage("Rating is required")
                .GreaterThan(0).WithMessage("Rating must be greater than 0")
                .LessThan(6).WithMessage("Rating must be greater than 0");
            #endregion
        }
    }
}
