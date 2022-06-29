using AutoMapper;
using FluentValidation;
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
    public class EfCreateCommentCommand: EfUseCase, ICreateCommentCommand
    {
        private readonly CreateCommentValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 23;
        public string Name => "Create Comment (EF)";
        public string Description => "Use case for creating new Comment using EF";
        #endregion


        public EfCreateCommentCommand
        (
            HimboDbContext context,
            CreateCommentValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(CommentDto request)
        {
            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Comment
            var comment = _mapper.Map<Domain.Entities.Comment>(request);
            #endregion

            #region Create and Save
            Context.AddEntity(comment);
            #endregion
        }
    }
}
