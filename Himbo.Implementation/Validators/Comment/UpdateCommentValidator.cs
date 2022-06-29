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
    public class UpdateCommentValidator: AbstractValidator<CommentDtoUpdate>
    {
        private readonly HimboDbContext _context;
        public UpdateCommentValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new ICommentValidator());
            #endregion

            #region Validate
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Comment Id is required")
                .Must(x => _context.Comments.Any(c => c.Id == x && c.IsActive))
                .WithMessage("Cannot find Comment with that Id.");
            #endregion
        }
    }
}
