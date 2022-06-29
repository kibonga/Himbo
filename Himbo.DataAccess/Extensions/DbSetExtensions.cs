using Himbo.Application.Exceptions;
using Himbo.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Extensions
{
    public static class DbSetExtensions
    {

        #region Crud Operations 
        public static void AddEntity<T>(this HimboDbContext context, T entity)
            where T : BaseEntity
        {
            // Potential additional logic
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public static void RemoveEntity<T>(this HimboDbContext context, T entity)
            where T : BaseEntity
        {
            // Potential additional logic
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public static void UpdateEntity<T>(this HimboDbContext context, T entity)
            where T : BaseEntity
        {
            // Potential additional logic
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        #endregion

        #region Getters
        public static T GetByIdAndThrow<T>(this HimboDbContext context, int id, bool isActive = true)
            where T : BaseEntity
        {
            var data = context.GetIf<T>(x => x.Id == id && (isActive ? x.IsActive : !x.IsActive));
            if (data == null)
            {
                throw new EntityNotFoundException(typeof(T).Name, id);
            }
            return data;
        }

        public static T GetIf<T>(this HimboDbContext context, Expression<Func<T, bool>> predicate = null)
            where T : BaseEntity
        {
            var data = context.Set<T>().FirstOrDefault(predicate) as T;
            return data;
        }
        
        public static T GetIfById<T>(this HimboDbContext context, Expression<Func<T, bool>> predicate = null)
            where T : BaseEntity
        {
            var data = context.Set<T>().FirstOrDefault(predicate) as T;
            return data;
        }
        #endregion

        #region Exist
        public static bool BaseEntityExistsAndThrow<T>(this HimboDbContext context, Expression<Func<T, bool>> predicate = null)
            where T : BaseEntity
        {
            return context.Set<T>().Any(predicate);
        } 
        #endregion

        #region Activate / Deactivate
        public static void Activate(this HimboDbContext context, BaseEntity entity)
        {
            entity.IsActive = true;
            context.Entry(entity).State = EntityState.Modified;
        }

        public static void Deactivate(this HimboDbContext context, BaseEntity entity)
        {
            entity.IsActive = false;
            context.Entry(entity).State = EntityState.Modified;
        }

        public static void DeactivateId<T>(this DbContext context, int id)
            where T : BaseEntity
        {
            var itemToDeactivate = context.Set<T>().Find(id);

            if (itemToDeactivate == null)
            {
                throw new EntityNotFoundException(nameof(T), id);
            }

            itemToDeactivate.IsActive = false;
        }

        public static void DeactivateRange<T>(this DbContext context, IEnumerable<int> ids)
            where T : BaseEntity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var d in toDeactivate)
            {
                d.IsActive = false;
            }

        } 
        #endregion
    }
}
