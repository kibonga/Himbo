using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Auth
{
    public class RegisterUserValidator : AbstractValidator<RegisterDto>
    {
        public RegisterUserValidator(HimboDbContext _context)
        {
            #region Email Validation
            RuleFor(x => x.Email)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Email is not in good format.")
                    .Must(email =>
                    {
                        return !_context.Users.Any(u => u.Email == email);
                    })
                    .WithMessage("Email address {PropertyValue} is already in use.");
            #endregion

            #region First and Last Name Validation
            var firstLastNameRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First Name is required")
                .Matches(firstLastNameRegex).WithMessage("First Name is not in good format");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last Name is required")
                .Matches(firstLastNameRegex).WithMessage("Last Name is not in good format");
            #endregion

            #region Password Validation
            var passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Matches(passwordRegex).WithMessage("Password must contain at least 8 characters, one Uppercase, one Lowercase, Number, and a Special character.");
            #endregion
        }
    }
}
