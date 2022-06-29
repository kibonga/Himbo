using Himbo.Application.UseCases.Commands.Post;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Post
{
    public class EfDeletePostCommand: EfUseCase, IDeletePostCommand
    {
        #region UsesCase Data
        public int Id => 20;
        public string Name => "Delete Post (EF)";
        public string Description => "Use case for deleting existing Post using EF";
        #endregion

        public EfDeletePostCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Post exists
            var post = Context.GetByIdAndThrow<Domain.Entities.Post>(request);
            #endregion

            #region Check if Post can be deleted
            post.OnDeletePostHasRatingsAndThrow();
            #endregion

            #region Remove Post
            Context.RemoveEntity(post);
            #endregion
        }
    }
}
