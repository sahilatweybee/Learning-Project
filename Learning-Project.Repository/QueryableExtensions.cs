using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.Repository
{
    public static class QueryableExtensions
    {
        public static async Task<List<T>?> ToListAsync<T>(this IQueryable<T> queryable)
        {
            return await queryable.ToListAsync();
        }\

        public static async Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter = null!)
        {
            return await queryable.FirstOrDefaultAsync(filter);
        }

        public static async Task<T?> FirstAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter = null!)
        {
            return await queryable.FirstAsync(filter);
        }

    }
}
