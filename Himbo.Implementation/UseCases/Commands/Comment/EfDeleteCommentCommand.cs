using Himbo.Application.UseCases.Commands.Comment;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Comment
{
    public class EfDeleteCommentCommand: EfUseCase, IDeleteCommentCommand
    {
        #region UsesCase Data
        public int Id => 27;
        public string Name => "Delete Comment (EF)";
        public string Description => "Use case for deleting existing Comment using EF";
        #endregion

        public EfDeleteCommentCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Comment exists
            var comment = Context.GetByIdAndThrow<Domain.Entities.Comment>(request);
            #endregion

            #region Check if Comment can be deleted
            #endregion

            #region Remove Comment
            Context.RemoveEntity(comment);
            #endregion
        }
    }
}
