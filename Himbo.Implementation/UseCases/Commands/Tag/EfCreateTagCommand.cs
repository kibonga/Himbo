using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases;
using Himbo.Application.UseCases.Commands.Tag;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Validators.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Tag
{
    public class EfCreateTagCommand : EfUseCase, ICreateTagCommand
    {
        private readonly CreateTagValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 2;
        public string Name => "Create Tag (EF)";
        public string Description => "Use case for creating new Tag using EF";
        #endregion

        public EfCreateTagCommand
        (
            HimboDbContext context,
            CreateTagValidator validator,
            IMapper mapper
        ) 
            : base(context)
        {
           _validator = validator;
           _mapper = mapper;
        }

        public void Execute(TagDto request)
        {
            #region Validate Tag
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Tag
            var tag = _mapper.Map<Domain.Entities.Tag>(request);
            #endregion

            #region Add Tag
            Context.AddEntity(tag);
            #endregion
        }
    }
}
