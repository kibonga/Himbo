using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Group
{
    public class IGroupValidator : AbstractValidator<GroupDto>
    {
        private readonly HimboDbContext _context;
        public IGroupValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Validation

            #endregion

            #region Validate
            Include(new NameValidator<Domain.Group>(_context));
            #endregion
        }
    }
}
