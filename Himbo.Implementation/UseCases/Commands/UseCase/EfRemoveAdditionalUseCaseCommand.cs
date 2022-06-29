using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.UseCase;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.UseCase
{
    public class EfRemoveAdditionalUseCaseCommand: EfUseCase, IRemoveAdditionalUseCaseCommand
    {
        private readonly RemoveAdditionalUseCaseValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 47;
        public string Name => "Remove Additional UseCase for User (EF)";
        public string Description => "Use case for removing additional UseCase for User using EF";
        #endregion

        public EfRemoveAdditionalUseCaseCommand
        (
            HimboDbContext context,
            RemoveAdditionalUseCaseValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(UseCaseDtoManager request)
        {
            #region Validate Group
            _validator.ValidateAndThrow(request);
            #endregion

            #region Remove UseCase
            var useCases = Context.UseCases.Where(uc => request.UseCaseIds.Contains(uc.Id)).ToList();
            var user = Context.Users.FirstOrDefault(u => u.Id == request.UserId && u.IsActive);
            foreach (var uc in useCases)
            {
                user.AdditionalUseCases.Remove(uc);
            };
            #endregion

            #region MyRegion
            Context.SaveChanges();
            #endregion
        }
    }
}
