using Himbo.Application.Exceptions;
using Himbo.Application.UseCases.Commands.Tag;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Tag
{
    public class EfDeleteTagCommand: EfUseCase, IDeleteTagCommand
    {

        #region UsesCase Data
        public int Id => 4;
        public string Name => "Delete Tag (EF)";
        public string Description => "Use case for deleting existing Tag using EF";
        #endregion


        public EfDeleteTagCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Tag
            var tag = Context.GetByIdAndThrow<Domain.Entities.Tag>(request);
            #endregion

            #region Check if Tag is linked to any Post
            tag.OnDeleteTagHasPostsAndThrow();
            #endregion

            #region Remove Tag
            Context.RemoveEntity(tag);
            #endregion
        }
    }
}
