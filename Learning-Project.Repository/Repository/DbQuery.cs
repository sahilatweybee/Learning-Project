using Learning_Project.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.Repository
{
    public class DbQuery<TEntity>
        where TEntity : class
    {
        private IQueryable<TEntity> dbSet;

        private bool SortByDesc = false;
        private bool AsTracking = true;
        private int PageNo = 1;
        private int PageSize = 100;
        private Expression<Func<TEntity, bool>> filter = null;
        private Expression<Func<TEntity, object>> sortExpression = null;

        public DbQuery(IQueryable<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        public DbQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter)
        {
            this.filter = filter;
            return this;
        }

        public DbQuery<TEntity> Sort(Expression<Func<TEntity, object>> sort, bool isDesc = false)
        {
            sortExpression = sort;
            SortByDesc = isDesc;
            return this;
        }

        public DbQuery<TEntity> Sort(string propName, bool isDesc = false)
        {
            SortByDesc = isDesc;
            sortExpression = Expressions.CreateMemberExpression<TEntity>(propName);

            return this;
        }

        public DbQuery<TEntity> AsNoTracking()
        {
            AsTracking = false;
            return this;
        }

        public IQueryable<TEntity> Get()
        {
            var result = AsTracking ? dbSet : dbSet.AsNoTracking();

            if (filter != null)
                result = result.Where(filter);

            if(sortExpression != null)
                if (SortByDesc)
                    result.OrderByDescending(sortExpression);
                else
                    result.OrderBy(sortExpression);

            return result;
        }

        public IQueryable<TEntity> GetPage(out int count)
        {
            count = 0;
            var result = Get();

            count = result.CountAsync().Result;

            return result.Skip((PageNo - 1) * PageSize).Take(PageSize);
        }
    }
}
