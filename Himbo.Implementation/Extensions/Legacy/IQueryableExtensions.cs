using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Legacy
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TSource> MyDelegate<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return source.MyDelegate(predicate);
        }
    }
}
