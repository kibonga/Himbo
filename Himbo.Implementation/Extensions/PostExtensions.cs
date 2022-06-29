using Himbo.Application.Exceptions;
using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions
{
    public static class PostExtensions
    {
        #region On Delete
        public static void OnDeletePostHasRatingsAndThrow(this Post post)
        {
            if (post.Ratings.Any())
            {
                throw new UseCaseConflictException("Cannot delete Post, because it has Ratings linked to it.");
            }
        }
        #endregion
    }
}
