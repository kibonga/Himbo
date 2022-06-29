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
    public class EfActivatePostCommand: EfUseCase, IActivatePostCommand
    {
        #region UsesCase Data
        public int Id => 19;
        public string Name => "Activate Post (EF)";
        public string Description => "Use case for activating existing Post using EF";
        #endregion


        public EfActivatePostCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Post by Id
            var post = Context.GetByIdAndThrow<Domain.Entities.Post>(request, false);
            #endregion

            #region Activate
            Context.Activate(post);
            Context.SaveChanges();
            #endregion
        }
    }
}
