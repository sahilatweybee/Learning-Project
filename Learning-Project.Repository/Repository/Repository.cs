using Learning_Project.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Learning_Project.Repository
{
    internal class Repository<TContext, TEntity> : IRepository<TContext, TEntity> where TContext : DbContext
        where TEntity : class
    {
        private bool _disposed = false;
        private TContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        private async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return await _dbSet.FirstOrDefaultAsync(filter) ?? default;
        }

        public async Task<TEntity?> FindByIdAsync(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var value = await _dbSet.FindAsync(id);

            return value ?? default;
        }

        public DbQuery<TEntity> Query()
        {
            return new DbQuery<TEntity>(_dbSet);
        }

        #region Insert

        public virtual void Insert(TEntity entity)
        {
            var entry = _dbSet.Attach(entity);
            entry.State = EntityState.Added;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void InsertWithNavigations(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void InsertCollection(List<TEntity> entityCollection)
        {
            _dbSet.AddRange(entityCollection);
        }

        public virtual async Task InsertCollectionAsync(List<TEntity> entityCollection)
        {
            await _dbSet.AddRangeAsync(entityCollection);
        }

        #endregion

        #region Update

        public virtual void Update(TEntity entity)
        {
            var entry = _dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void UpdateWithNavigations(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void UpdateCollection(List<TEntity> entityCollection)
        {
            _dbSet.UpdateRange(entityCollection);
        }

        #endregion

        #region Delete

        public virtual void Delete(TEntity entity)
        {
            var entry = _dbSet.Attach(entity);
            entry.State = EntityState.Deleted;
        }

        public virtual void DeleteWithNavigations(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteCollection(List<TEntity> entityCollection)
        {
            _dbSet.RemoveRange(entityCollection);
        }

        #endregion

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _dbContext?.Dispose();
            _disposed = true;
        }
    }
}
