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
    public class EfActivateCommentCommand: EfUseCase, IActivateCommentCommand
    {
        #region UsesCase Data
        public int Id => 26;
        public string Name => "Activate Comment (EF)";
        public string Description => "Use case for activating existing Comment using EF";
        #endregion


        public EfActivateCommentCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Comment by Id
            var comment = Context.GetByIdAndThrow<Domain.Entities.Comment>(request, false);
            #endregion

            #region Activate all Child comments
            ActivateChildrenComments(comment, comment.UpdatedAt);
            #endregion

            #region Activate
            Context.Activate(comment);
            Context.SaveChanges();
            #endregion
        }

        private void ActivateChildrenComments(Domain.Entities.Comment comment, DateTime? time = null)
        {
            if (comment.Children.Any())
            {
                foreach (var c in comment.Children)
                {
                    if(!c.IsActive)
                    {
                        c.IsActive = true;
                    }
                    ActivateChildrenComments(c, time);
                };
            }
        }
    }
}
