using Himbo.Application.Exceptions;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Extensions
{
    public static class DbCategoryExtensions
    {
        #region Get Category with Image
        public static Category GetCategoryByIdAndThrow(this HimboDbContext context, int id)
        {
            #region Get Category
            var category = context.Categories
                    .Include(x => x.Image)
                    .FirstOrDefault(x => x.Id == id && x.IsActive);
            #endregion

            #region Validate
            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Post).Name, id);
            } 
            #endregion

            return category;
        }
        #endregion
    }
}
