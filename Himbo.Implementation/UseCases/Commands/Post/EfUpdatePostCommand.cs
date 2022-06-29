using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Post;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.DataAccess.Extensions;
using Himbo.Implementation.Extensions;
using Himbo.Implementation.Extensions.Common;
using Himbo.Implementation.Validators.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Post
{
    public class EfUpdatePostCommand: EfUseCase, IUpdatePostCommand
    {
        private readonly UpdatePostValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 17;
        public string Name => "Update Post (EF)";
        public string Description => "Use case for updating existing Post using EF";
        #endregion


        public EfUpdatePostCommand
        (
            HimboDbContext context,
            UpdatePostValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(PostDto request)
        {
            #region Get Post by Id
            var post = Context.GetByIdAndThrow<Domain.Entities.Post>(request.Id.Value);
            #endregion

            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Add Banner Image
            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                post.AddImage(request.ImageFileName, _mapper);
            }
            #endregion

            #region Add Many Images
            if (request.ImageFileNames != null)
            {
                post.AddImages(request.ImageFileNames, _mapper);
            }
            #endregion

            #region Add Tags to Post
            Context.AddTagsToPost(post, request);
            #endregion

            #region Map Post
            _mapper.Map(request, post);
            #endregion

            #region Update Post
            Context.UpdateEntity(post);
            #endregion
        }
    }
}
