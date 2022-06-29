using FluentValidation;
using Himbo.Application.UseCases.DTO.Common;
using Himbo.DataAccess;
using Himbo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Common
{
    public class MetaValidator : AbstractValidator<MetaDto>
    {

        public MetaValidator()
        {
            #region Validate Metas
            RuleFor(x => x.MetaTitle)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(30).WithMessage("Maximum number of characters is 30");
            RuleFor(x => x.MetaDescription)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(100).WithMessage("Maximum number of characters is 100");
            #endregion

            #region Validate Slug
            var slugRegex = @"^[a-z0-9]+(?:-[a-z0-9]+)*$";
            RuleFor(x => x.Slug)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimum number of characters is 3.")
                .MaximumLength(20).WithMessage("Maximum number of characters is 20")
                .Matches(slugRegex).WithMessage("Slug is not in good format (eg. slug-name-format)");
            #endregion

        }
    }
}
