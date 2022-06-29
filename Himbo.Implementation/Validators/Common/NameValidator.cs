using FluentValidation;
using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using Himbo.DataAccess;
using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Common
{
    public class NameValidator<T> : AbstractValidator<BaseDtoWithName>
        where T : BaseEntitiyWithName
    {

        private readonly HimboDbContext _context;

        public NameValidator
        (
            HimboDbContext context
        )
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validate Name
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Name is required").When(x => x.Id.HasValue)
                .NotEmpty().WithMessage("Name cannot be empty").When(x => x.Id.HasValue)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(100).WithMessage("Maximum number of characters is 100");
            //RuleFor(x => x).Must(x => _context.Set<T>().Any(y => y.Title == x.Title && x.Id == y.Id)).WithMessage("Property {PropertyValue} is already in use.");
            RuleFor(x => x.Name).Must(NameNotInUse).WithMessage("Property {PropertyValue} is already in use.").When(IdsAreDifferent);
            #endregion
        }

        #region Check if Title already Exists 
        private bool NameNotInUse(string name)
        {
            return !_context.Set<T>().Any(x => x.Name == name);
        }
        #endregion

        private bool IdsAreDifferent(BaseDtoWithName dto)
        {
            return _context.Set<T>().Any(x => x.Id != dto.Id && x.Name == dto.Name);

        }
    }
}
