using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Post
{
    public class UpdatePostValidator : AbstractValidator<PostDto>
    {
        private readonly HimboDbContext _context;
        public UpdatePostValidator(HimboDbContext context)
        {
            #region DbContext
            this._context = context;
            #endregion

            #region Include
            Include(new IPostValidator(_context));
            Include(new MetaValidator());
            Include(new TitleValidator<Domain.Entities.Post>(_context));
            #endregion

            #region Validate
            #endregion
        }
    }
}
