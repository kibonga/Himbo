using Himbo.Application.UseCases.Commands.Category;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Category
{
    public class EfActivateCategoryCommand: EfUseCase, IActivateCategoryCommand
    {
        #region UsesCase Data
        public int Id => 12;
        public string Name => "Activate Category (EF)";
        public string Description => "Use case for activating existing Category using EF";
        #endregion


        public EfActivateCategoryCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Category by Id
            var category = Context.GetByIdAndThrow<Domain.Entities.Category>(request, false);
            #endregion

            #region Activate
            Context.Activate(category);
            Context.SaveChanges();
            #endregion
        }
    }
}
