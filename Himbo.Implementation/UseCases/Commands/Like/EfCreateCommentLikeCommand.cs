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
    public class EfCreateCommentLikeCommand: EfUseCase, ICreateCommentLikeCommand
    {
        private readonly CreateCommentLikeValidator _validator;

        #region UsesCase Data
        public int Id => 31;
        public string Name => "Create Comment Like (EF)";
        public string Description => "Use case for creating new Comment Like using EF";
        #endregion


        public EfCreateCommentLikeCommand
        (
            HimboDbContext context,
            CreateCommentLikeValidator validator
        )
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(LikeDtoComment request)
        {
            #region Validate Post
            _validator.ValidateAndThrow(request);
            #endregion

            #region Create Like
            var comment = Context.Comments.FirstOrDefault(x => request.LikedCommentsId.Value == x.Id);
            var user = Context.Users.FirstOrDefault(x => request.UsersWhoLikedId.Value == x.Id);
            comment.UsersWhoLiked.Add(user);
            #endregion

            #region Save
            Context.SaveChanges();
            #endregion
        }
    }
}
