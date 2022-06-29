using Himbo.Application.UseCases.Commands.Like;
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
    public class EfDeleteCommentLikeCommand: EfUseCase, IDeleteCommentLikeCommand
    {
        #region UsesCase Data
        public int Id => 32;
        public string Name => "Delete Comment Like (EF)";
        public string Description => "Use case for deleting existing Comment Like using EF";
        #endregion

        public EfDeleteCommentLikeCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int commentId, int userId)
        {
            #region Check if Post and User exist
            var comment = Context.GetByIdAndThrow<Domain.Entities.Comment>(commentId);
            var user = Context.GetByIdAndThrow<User>(userId);
            #endregion

            #region Remove Comment
            comment.UsersWhoLiked.Remove(user);
            Context.SaveChanges();
            #endregion
        }
    }
}
