using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Comment
{
    public class CreateCommentValidator: AbstractValidator<CommentDto>
    {
        private readonly HimboDbContext _context;
        public CreateCommentValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new ICommentValidator());
            #endregion

            #region Validate
            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Post Id is required")
                .Must(x => _context.Posts.Any(p => p.Id == x && p.IsActive))
                .WithMessage("Post Id is not valid");
            RuleFor(x => x.ParentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => _context.Comments.Any(c => c.Id == x && c.IsActive))
                .WithMessage("Parent Comment Id is not valid")
                .When(x => x.ParentId.HasValue);
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Id is required")
                .Must(x => _context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("User Id is not valid");
            #endregion
        }
    }
}
