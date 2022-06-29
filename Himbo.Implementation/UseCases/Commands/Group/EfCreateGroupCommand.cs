using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Validators.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Group
{
    internal class EfCreateGroupCommand : EfUseCase, ICreateGroupCommand
    {

        private readonly CreateGroupValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 35;
        public string Name => "Create Group (EF)";
        public string Description => "Use case for creating new Group using EF";
        #endregion

        public EfCreateGroupCommand
        (
            HimboDbContext context,
            CreateGroupValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(GroupDto request)
        {
            #region Validate Group
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Group
            var group = _mapper.Map<Domain.Group>(request);
            #endregion

            #region MyRegion
            Context.AddEntity(group);
            #endregion
        }
    }
}
