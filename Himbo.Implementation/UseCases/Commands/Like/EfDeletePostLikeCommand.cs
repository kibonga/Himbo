using Himbo.Application.UseCases.Commands.Like;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Like
{
    public class EfDeletePostLikeCommand: EfUseCase, IDeletePostLikeCommand
    {
        #region UsesCase Data
        public int Id => 30;
        public string Name => "Delete Post Like (EF)";
        public string Description => "Use case for deleting existing Post Like using EF";
        #endregion

        public EfDeletePostLikeCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int postId, int userId)
        {
            #region Check if Post and User exist
            var post = Context.GetByIdAndThrow<Domain.Entities.Post>(postId);
            var user = Context.GetByIdAndThrow<User>(userId);
            #endregion

            #region Remove Comment
            post.UsersWhoLiked.Remove(user);
            Context.SaveChanges();
            #endregion
        }
    }
}
