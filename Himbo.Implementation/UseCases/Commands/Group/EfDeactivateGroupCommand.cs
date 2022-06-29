using Himbo.Application.UseCases.Commands.Group;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Group
{
    public class EfDeactivateGroupCommand: EfUseCase, IDeactivateGroupCommand
    {
        #region UsesCase Data
        public int Id => 38;
        public string Name => "Deactivate Group (EF)";
        public string Description => "Use case for deactivating existing Group using EF";
        #endregion


        public EfDeactivateGroupCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Check if Group exists
            var group = Context.GetByIdAndThrow<Domain.Group>(request);
            #endregion

            #region Deactivate Group
            Context.Deactivate(group);
            Context.SaveChanges();
            #endregion
        }
    }
}
