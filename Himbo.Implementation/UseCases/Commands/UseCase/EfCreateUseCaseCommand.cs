using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.UseCase;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Validators.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.UseCase
{
    public class EfCreateUseCaseCommand: EfUseCase, ICreateUseCaseCommand
    {
        private readonly CreateUseCaseValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 42;
        public string Name => "Create UseCase (EF)";
        public string Description => "Use case for creating new UseCase using EF";
        #endregion

        public EfCreateUseCaseCommand
        (
            HimboDbContext context,
            CreateUseCaseValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(UseCaseDto request)
        {
            #region Validate Group
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Group
            var useCase = _mapper.Map<Domain.UseCase>(request);
            #endregion

            #region Add Use Case to Admin
            var adminGroup = Context.Groups.FirstOrDefault(g => g.Name == "Admin");
            var adminUseCases = adminGroup.UseCases.ToList();
            adminUseCases.Add(useCase);
            adminGroup.UseCases = adminUseCases;
            #endregion

            #region MyRegion
            Context.AddEntity(useCase);
            #endregion
        }
    }
}
