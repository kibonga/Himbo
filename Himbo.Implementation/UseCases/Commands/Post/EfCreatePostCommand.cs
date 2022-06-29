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
    public class EfCreatePostCommand: EfUseCase, ICreatePostCommand
    {
        private readonly CreatePostValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 16;
        public string Name => "Create Post (EF)";
        public string Description => "Use case for creating new Category using EF";
        #endregion


        public EfCreatePostCommand
        (
            HimboDbContext context,
            CreatePostValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(PostDto request)
        {
            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Map Post
            var post = _mapper.Map<Domain.Entities.Post>(request);
            #endregion

            #region Add Banner Image
            if(!string.IsNullOrEmpty(request.ImageFileName))
            {
                post.AddImage(request.ImageFileName, _mapper);
            }
            #endregion

            #region Add Many Images
            if(request.ImageFileNames != null)
            {
                post.AddImages(request.ImageFileNames, _mapper);
            }
            #endregion

            #region Add Tags to Post
            Context.AddTagsToPost(post, request);
            #endregion

            #region Create and Save
            Context.AddEntity(post);
            #endregion
        }
    }
}
