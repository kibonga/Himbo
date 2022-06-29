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
    public class CreatePostLikeValidator : AbstractValidator<LikeDtoPost>
    {
        private readonly HimboDbContext _context;
        public CreatePostLikeValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new ILikeValidator(_context));
            #endregion

            #region Validation
            RuleFor(x => x.LikedPostsId)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("Post Id is required")
                    .Must(x => _context.Posts.Any(p => p.Id == x.Value && p.IsActive))
                    .WithMessage("Invalid Post Id.");
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Like Dto is required")
                .Must(x => !_context.Posts.Any(p => p.UsersWhoLiked.Any(u => u.Id == x.UsersWhoLikedId && u.IsActive) && p.Id == x.LikedPostsId && p.IsActive))
                .WithMessage("User has already liked this Post"); 
            #endregion
        }
}
}
