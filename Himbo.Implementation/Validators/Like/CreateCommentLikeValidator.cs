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
    public class CreateCommentLikeValidator : AbstractValidator<LikeDtoComment>
    {
        private readonly HimboDbContext _context;
        public CreateCommentLikeValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new ILikeValidator(_context));
            #endregion

            #region Validation
            RuleFor(x => x.LikedCommentsId)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("Comment Id is required")
                    .Must(x => _context.Comments.Any(p => p.Id == x.Value && p.IsActive))
                    .WithMessage("Invalid Comment Id.");
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Like Dto is required")
                .Must(x => !_context.Comments.Any(p => p.UsersWhoLiked.Any(u => u.Id == x.UsersWhoLikedId && u.IsActive) && p.Id == x.LikedCommentsId && p.IsActive))
                .WithMessage("User has already liked this Comment");
            #endregion
        }
    }
}
