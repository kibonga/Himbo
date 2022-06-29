using Himbo.Application.UseCases.Commands.Post;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Post
{
    public class EfDeactivatePostCommand : EfUseCase, IDeactivatePostCommand
    {
        #region UsesCase Data
        public int Id => 18;
        public string Name => "Deactivate Post (EF)";
        public string Description => "Use case for deactivating existing Post using EF";
        #endregion

        public EfDeactivatePostCommand(HimboDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Post exists
            var post = Context.GetByIdAndThrow<Domain.Entities.Post>(request);
            #endregion

            #region Deactivate Post
            Context.Deactivate(post);
            Context.SaveChanges();
            #endregion
        }
    }
}
