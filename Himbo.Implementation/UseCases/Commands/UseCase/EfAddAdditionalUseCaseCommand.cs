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
    public class EfAddAdditionalUseCaseCommand: EfUseCase, IAddAdditionalUseCaseCommand
    {
        private readonly AddAdditionalUseCaseValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 46;
        public string Name => "Add Additional UseCase for User (EF)";
        public string Description => "Use case for adding additional UseCase for User using EF";
        #endregion

        public EfAddAdditionalUseCaseCommand
        (
            HimboDbContext context,
            AddAdditionalUseCaseValidator validator,
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

            #region Map Group
            var useCases = Context.UseCases.Where(uc => request.UseCaseIds.Contains(uc.Id)).ToList();
            var user = Context.Users.FirstOrDefault(u => u.Id == request.UserId && u.IsActive);
            foreach (var uc in useCases)
            {
                user.AdditionalUseCases.Add(uc);
            };
            #endregion

            #region MyRegion;
            Context.SaveChanges();
            #endregion
        }
    }
}
