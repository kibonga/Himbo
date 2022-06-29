using Himbo.Application.UseCases.Commands.Tag;
using Himbo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himbo.Implementation.Extensions.Common;
using Himbo.Implementation.Extensions;
using System.Linq.Expressions;
using Himbo.DataAccess.Extensions;

namespace Himbo.Implementation.UseCases.Commands.Tag
{
    public class EfDeactivateTagCommand: EfUseCase, IDeactivateTagCommand
    {
        #region UsesCase Data
        public int Id => 7;
        public string Name => "Deactivate Tag (EF)";
        public string Description => "Use case for deactivating existing Tag using EF";
        #endregion


        public EfDeactivateTagCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Tag By Id
            var tag = Context.GetByIdAndThrow<Domain.Entities.Tag>(request);
            #endregion

            #region Deactivate
            Context.Deactivate(tag);
            Context.SaveChanges();
            #endregion
        }

    }
}
