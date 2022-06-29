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
    public class EfDeactivateCategoryCommand: EfUseCase, IDeactivateCategoryCommand
    {
        #region UsesCase Data
        public int Id => 11;
        public string Name => "Deactivate Category (EF)";
        public string Description => "Use case for deactivating existing Category using EF";
        #endregion


        public EfDeactivateCategoryCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Category exists
            var category = Context.GetByIdAndThrow<Domain.Entities.Category>(request);
            #endregion

            #region Deactivate Category
            Context.Deactivate(category);
            Context.SaveChanges();
            #endregion
        }
    }
}
