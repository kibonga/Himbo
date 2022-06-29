using FluentValidation;
using Himbo.Application.UseCases.DTO.Common;
using Himbo.DataAccess;
using Himbo.Domain;
using Himbo.Domain.Common;
using Himbo.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Common
{
    public class TitleValidator<T> : AbstractValidator<BaseDtoWithMeta>
        where T : BaseEntityWithTitle
    {

        private readonly HimboDbContext _context;

        public TitleValidator
        (
            HimboDbContext context
        )
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validate Title
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Title is required").When(x => x.Id.HasValue)
                .NotEmpty().WithMessage("Title cannot be empty").When(x => x.Id.HasValue)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(100).WithMessage("Maximum number of characters is 100");
            //RuleFor(x => x).Must(x => _context.Set<T>().Any(y => y.Title == x.Title && x.Id == y.Id)).WithMessage("Property {PropertyValue} is already in use.");
            RuleFor(x => x.Title).Must(TitleNotInUse).WithMessage("Property {PropertyValue} is already in use.").When(IdsAreDifferent);
            #endregion
        }

        #region Check if Title already Exists 
        private bool TitleNotInUse(string title)
        {
            return !_context.Set<T>().Any(x => x.Title == title);
        }
        #endregion

        private bool IdsAreDifferent(BaseDtoWithMeta dto)
        {
            return _context.Set<T>().Any(x => x.Id != dto.Id && x.Title == dto.Title);
        }
    }
}
