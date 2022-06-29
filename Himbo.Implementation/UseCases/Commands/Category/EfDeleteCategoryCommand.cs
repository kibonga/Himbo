using Himbo.Application.UseCases.Commands.Category;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Category
{
    public class EfDeleteCategoryCommand: EfUseCase, IDeleteCategoryCommand
    {

        #region UsesCase Data
        public int Id => 15;
        public string Name => "Delete Category (EF)";
        public string Description => "Use case for deleting existing Category using EF";
        #endregion

        public EfDeleteCategoryCommand
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

            #region Check if Category can be deleted
            category.OnDeleteCategoryHasChildrenAndThrow();
            category.OnDeleteCategoryHasPostsAndThrow();
            #endregion

            #region Remove Category
            Context.RemoveEntity(category);
            #endregion
        }
    }
}
