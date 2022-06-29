using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases;
using Himbo.Application.UseCases.Commands.Comment;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Comment
{
    public class EfUpdateCommentCommand: EfUseCase, IUpdateCommentCommand
    {
        private readonly UpdateCommentValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 24;
        public string Name => "Update Comment (EF)";
        public string Description => "Use case for updating existing Comment using EF";
        #endregion


        public EfUpdateCommentCommand
        (
            HimboDbContext context,
            UpdateCommentValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(CommentDtoUpdate request)
        {
            #region Get Comment by Id
            var comment = Context.GetByIdAndThrow<Domain.Entities.Comment>(request.Id.Value);
            #endregion

            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Post
            _mapper.Map(request, comment);
            #endregion

            #region Update Post
            Context.UpdateEntity(comment);
            #endregion
        }
    }
}
