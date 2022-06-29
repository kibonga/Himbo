using Himbo.Application.UseCases.Commands.Tag;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Tag
{
    public class EfActivateTagCommand: EfUseCase, IActivateTagCommand
    {
        #region UsesCase Data
        public int Id => 8;
        public string Name => "Activate Tag (EF)";
        public string Description => "Use case for activating existing Tag using EF";
        #endregion

        public EfActivateTagCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Tag By Id
            var tag = Context.GetByIdAndThrow<Domain.Entities.Tag>(request, false);
            #endregion

            #region Activate
            Context.Activate(tag);
            Context.SaveChanges();
            #endregion

        }
    }
}
