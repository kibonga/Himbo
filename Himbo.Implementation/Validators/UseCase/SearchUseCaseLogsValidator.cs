using FluentValidation;
using Himbo.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.UseCase
{
    public class SearchUseCaseLogsValidator : AbstractValidator<UseCaseLogSearch>
    {
        public SearchUseCaseLogsValidator()
        {
            #region Validation
            RuleFor(x => x.DateFrom).NotEmpty()
                .WithMessage("Date from is required.")
                .Must(DateDiffLessThan15Days).WithMessage("Date diff must be less than 15 days.");
            RuleFor(x => x.DateTo).NotEmpty().WithMessage("Date to is required.");
            #endregion
        }

        #region Util
        private bool DateDiffLessThan15Days(UseCaseLogSearch search, DateTime? dateFrom)
        {
            if (!search.DateTo.HasValue)
            {
                return false;
            }

            var timeSpan = (search.DateTo - search.DateFrom).Value;

            return timeSpan.TotalDays <= 15;
        } 
        #endregion
    }
}
