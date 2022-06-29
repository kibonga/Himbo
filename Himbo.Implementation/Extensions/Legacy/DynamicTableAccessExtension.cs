using Himbo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Legacy
{
    public static partial class CustomExtensions
    {
        public static IQueryable QuerySet(this DbContext context, string entityName) =>
            context.QuerySet(context.Model.FindEntityType(entityName).ClrType);

        static readonly MethodInfo SetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set));

        public static IQueryable QuerySet(this DbContext context, Type entityType) =>
            (IQueryable)SetMethod.MakeGenericMethod(entityType).Invoke(context, null);
    }
}
