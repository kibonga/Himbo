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
    public class UpdateRatingValidator : AbstractValidator<RatingDto>
    {
        private readonly HimboDbContext _context;
        public UpdateRatingValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new IRatingValidator(_context));
            #endregion

            #region Validate
            RuleFor(x => x)
                .NotNull().WithMessage("Rating dto is required")
                .Must(x => _context.PostsRatings.FirstOrDefault(r => r.UserId == x.UserId && r.PostId == x.PostId).NumberOfStars != x.NumberOfStars)
                .WithMessage("Rating must be of different value");
            #endregion
        }
    }
}
