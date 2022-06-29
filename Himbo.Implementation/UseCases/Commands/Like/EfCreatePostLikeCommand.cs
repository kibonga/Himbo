using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Like;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Like
{
    public class EfCreatePostLikeCommand: EfUseCase, ICreatePostLikeCommand
    {
        private readonly CreatePostLikeValidator _validator;

        #region UsesCase Data
        public int Id => 29;
        public string Name => "Create Post Like (EF)";
        public string Description => "Use case for creating new Post Like using EF";
        #endregion


        public EfCreatePostLikeCommand
        (
            HimboDbContext context,
            CreatePostLikeValidator validator
        )
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(LikeDtoPost request)
        {
            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Create Like
            var post = Context.Posts.FirstOrDefault(x => request.LikedPostsId.Value == x.Id);
            var user = Context.Users.FirstOrDefault(x => request.UsersWhoLikedId.Value == x.Id);
            post.UsersWhoLiked.Add(user);
            #endregion

            #region Save
            Context.SaveChanges();
            #endregion
        }
    }
}
