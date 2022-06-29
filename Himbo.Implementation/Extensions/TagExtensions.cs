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
    public static class TagExtensions
    {

        #region Check if Post can be Deleted
        public static void OnDeleteTagHasPostsAndThrow(this Tag tag)
        {
            if (tag.Posts.Any())
            {
                throw new UseCaseConflictException("Cannot delete Tag, because it has Posts linked to it.");
            }
        } 
        #endregion

    }
}
