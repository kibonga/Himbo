using AutoMapper;
using Himbo.Application.Exceptions;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions
{
    public static class CategoryExtensions
    {

        #region Check if Category can be Deleted
        public static void OnDeleteCategoryHasChildrenAndThrow(this Category category)
        {
            if (category.Children.Any())
            {
                throw new UseCaseConflictException("Cannot delete Category, because it has Child categories linked to it.");
            }
        }

        public static void OnDeleteCategoryHasPostsAndThrow(this Category category)
        {
            if (category.Posts.Any())
            {
                throw new UseCaseConflictException("Cannot delete Category, because it has Posts linked to it.");
            }
        }
        #endregion
    }
}
