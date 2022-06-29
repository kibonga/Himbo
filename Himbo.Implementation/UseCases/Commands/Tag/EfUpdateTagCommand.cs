using AutoMapper;
using FluentValidation;
using Himbo.Application.Exceptions;
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
    public class EfUpdateTagCommand : EfUseCase, IUpdateTagCommand
    {
        private readonly UpdateTagValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 3;
        public string Name => "Update Tag (EF)";
        public string Description => "Use case for updating existing Tag using EF";
        #endregion

        public EfUpdateTagCommand
        (
            HimboDbContext context,
            UpdateTagValidator validator,
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

            #region Get Tag by Id
            var tag = Context.GetByIdAndThrow<Domain.Entities.Tag>(request.Id.Value);
            #endregion

            #region Map Tag
            _mapper.Map(request, tag);
            #endregion

            #region Update tag
            Context.UpdateEntity(tag);
            #endregion
        }
    }
}
