using FluentValidation;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Group
{
    public class CreateGroupValidator: AbstractValidator<GroupDto>
    {
        private readonly HimboDbContext _context;

        public CreateGroupValidator(HimboDbContext context)
        {
            #region DbContext
            _context = context;
            #endregion

            #region Include
            Include(new IGroupValidator(_context));
            #endregion
        }
    }
}
