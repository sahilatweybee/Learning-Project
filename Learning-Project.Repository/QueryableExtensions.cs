﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Learning_Project.Repository
{
    public static class QueryableExtensions
    {
        public static async Task<List<TEntity>?> ToListAsync<TEntity>(this IQueryable<TEntity> queryable)
        {
            return await queryable.ToListAsync();
        }

        public static async Task<TEntity?> FirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> filter = null!)
        {
            return await queryable.FirstOrDefaultAsync(filter);
        }

        public static async Task<TEntity?> FirstAsync<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> filter = null!)
        {
            return await queryable.FirstAsync(filter);
        }

        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TProperty>> property)
        {
            return queryable.Include(property); 
        }
    }
}
