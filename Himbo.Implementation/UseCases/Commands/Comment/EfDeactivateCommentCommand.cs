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
    public class EfDeactivateCommentCommand: EfUseCase, IDeactivateCommentCommand
    {
        #region UsesCase Data
        public int Id => 25;
        public string Name => "Deactivate Comment (EF)";
        public string Description => "Use case for deactivating existing Comment using EF";
        #endregion

        public EfDeactivateCommentCommand(HimboDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Comment exists
            var comment = Context.GetByIdAndThrow<Domain.Entities.Comment>(request);
            #endregion

            #region Deactivate all Child comments
            DeactivateChildrenComments(comment);
            #endregion

            #region Deactivate Comment
            Context.Deactivate(comment);
            Context.SaveChanges();
            #endregion
        }

        private void DeactivateChildrenComments(Domain.Entities.Comment comment)
        {
            if(comment.Children.Any())
            {
                foreach (var c in comment.Children)
                {
                    if(c.IsActive)
                    {
                        c.IsActive = false;
                    }
                    DeactivateChildrenComments(c);
                };
            }
        }
    }
}
