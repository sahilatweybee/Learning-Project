using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Learning_Project.Repository
{
    public static class QueryableExtensions
    {
        public static async Task<List<TEntity>?> ToListAsync<TEntity>(this IQueryable<TEntity> queryable)
        {
            return await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(queryable);
        }

        public static async Task<TEntity?> FirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> filter = null!)
        {
            return await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(queryable, filter);
        }

        //public static async Task<TEntity?> FirstAsync<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> filter = null!)
        //{
        //    return await queryable.FirstAsync(filter);
        //}

        public static IIncludableQueryable<TEntity, TProperty> IncludeEntity<TEntity, TProperty>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TProperty>> property)
            where TEntity : class
        {
            return queryable.Include(property);
        }
    }
}
