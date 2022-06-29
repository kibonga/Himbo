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
    public class EfActivateGroupCommand: EfUseCase, IActivateGroupCommand
    {
        #region UsesCase Data
        public int Id => 39;
        public string Name => "Activate Group (EF)";
        public string Description => "Use case for activating existing Group using EF";
        #endregion


        public EfActivateGroupCommand
        (
            HimboDbContext context
        )
            : base(context)
        {
        }

        public void Execute(int request)
        {
            #region Get Group by Id
            var group = Context.GetByIdAndThrow<Domain.Group>(request, false);
            #endregion

            #region Activate
            Context.Activate(group);
            Context.SaveChanges();
            #endregion
        }
    }
}
