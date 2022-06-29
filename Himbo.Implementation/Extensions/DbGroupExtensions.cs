using Himbo.Application.Exceptions;
using Himbo.DataAccess;
using Himbo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions
{
    public static class DbGroupExtensions
    {
        #region Get Group with Image
        public static Group GetGroupByIdAndThrow(this HimboDbContext context, int id)
        {
            #region Get Category
            var group = context.Groups
                    .Include(x => x.UseCases)
                    .Include(x => x.Users)
                    .FirstOrDefault(x => x.Id == id && x.IsActive);
            #endregion

            #region Validate
            if (group == null)
            {
                throw new EntityNotFoundException(typeof(Group).Name, id);
            }
            #endregion

            return group;
        }
        #endregion
    }
}
