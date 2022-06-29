using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Comment
{
    internal class ICommentValidator: AbstractValidator<IContentDto>
    {
        public ICommentValidator()
        {
            #region Validate
            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Comment is required.")
                .NotEmpty().WithMessage("Comment cannot be empty.")
                .MaximumLength(300).WithMessage("Comment cannot exceed 300 characters.");
            #endregion
        }
    }
}
