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
    public class CreateRatingValidator : AbstractValidator<RatingDto>
    {
        private readonly HimboDbContext _context;
        public CreateRatingValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new IRatingValidator(_context));
            #endregion

            #region Validation
            RuleFor(x => x)
                .NotNull().WithMessage("Rating dto is required")
                .Must(x => !_context.PostsRatings.Any(r => r.UserId == x.UserId && r.PostId == x.PostId))
                .WithMessage("User has already rated this Post");
            #endregion
        }
    }
}
