
using Himbo.Application.Exceptions;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Himbo.Implementation.Extensions
{
    public static class DbPostExtensions
    {

        #region Add to Post
        public static void AddTagsToPost(this HimboDbContext context, Post post, PostDto dto)
        {
            if (dto.TagIds != null && dto.TagIds.Any())
            {
                var tags = context.Tags.Where(x => dto.TagIds.Contains(x.Id) && x.IsActive).ToList();
                post.Tags.Clear();
                post.Tags = tags;
            }
        }
        #endregion

        #region Queries
        public static Post GetPostByIdAndThrow(this HimboDbContext context, int id)
        {
            var post = context.Posts
                .Include(x => x.Comments.Where(c => c.IsActive && (c.ParentId.HasValue ? c.Parent.IsActive : true)))
                .Include(x => x.Tags.Where(t => t.IsActive))
                .Include(x => x.Author)
                .Include(x => x.UsersWhoLiked.Where(u => u.IsActive))
                .Include(x => x.Ratings.Where(r => r.IsActive))
                .Include(x => x.Images.Where(i => i.IsActive))
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if(post == null)
            {
                throw new EntityNotFoundException(typeof(Post).Name, id);
            }

            return post;
        }
        #endregion

    }
}
