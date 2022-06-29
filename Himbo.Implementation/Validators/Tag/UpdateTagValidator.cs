using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Tag
{
    public class UpdateTagValidator: AbstractValidator<TagDto>
    {
        private readonly HimboDbContext _context;

        public UpdateTagValidator(HimboDbContext context)
        {
            #region DbContext
            this._context = context;
            #endregion

            #region Include
            Include(new MetaValidator()); // Meta validator doesn't require connection
            Include(new TitleValidator<Domain.Entities.Tag>(_context));
            #endregion
        }
    }
}
