using FluentValidation;
using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Group;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Group
{
    internal class EfRemoveGroupUseCasesCommand: EfUseCase, IRemoveGroupUseCasesCommand
    {
        private readonly RemoveGroupUseCasesValidator _validator;

        #region UsesCase Data
        public int Id => 37;
        public string Name => "Remove UseCases from Group (EF)";
        public string Description => "Remove UseCases from existing Group using EF";
        #endregion

        public EfRemoveGroupUseCasesCommand
        (
            HimboDbContext context,
            RemoveGroupUseCasesValidator validator
        )
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(GroupUseCasesIdsDto request)
        {
            #region Validate Group
            _validator.ValidateAndThrow(request);
            #endregion

            #region Update Group
            var listOfIds = string.Join(',', request.UseCasesIds);
            var sql = $@"DELETE  [GroupUseCase] WHERE UseCasesId in ({listOfIds}) AND GroupsId = {request.Id}";
            Context.Database.ExecuteSqlRaw(sql);
            #endregion
        }
    }
}
