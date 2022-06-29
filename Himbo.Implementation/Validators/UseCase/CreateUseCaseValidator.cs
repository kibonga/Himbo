using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.UseCase
{
    public class CreateUseCaseValidator : AbstractValidator<UseCaseDto>
    {
        private readonly HimboDbContext _context;

        public CreateUseCaseValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new IUseCaseValidator(_context));
            #endregion
        }
    }
}
