using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Validators.Group;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Group
{
    internal class EfAddGroupUseCasesCommand: EfUseCase, IAddGroupUseCasesCommand
    {
        private readonly AddGroupUseCasesValidator _validator;

        #region UsesCase Data
        public int Id => 36;
        public string Name => "Add UseCases to Group (EF)";
        public string Description => "Add UseCases to existing Group using EF";
        #endregion

        public EfAddGroupUseCasesCommand
        (
            HimboDbContext context,
            AddGroupUseCasesValidator validator,
            IMapper mapper
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

            #region Add UseCases to Group
            var useCases = Context.UseCases.Where(x => request.UseCasesIds.Contains(x.Id) && x.IsActive).ToList();
            var group = Context.Groups.FirstOrDefault(x => x.Id == request.Id && x.IsActive);
            group.UseCases = useCases;
            #endregion

            #region Update Group
            Context.SaveChanges();
            #endregion
        }
    }
}
