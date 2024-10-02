
using Microsoft.EntityFrameworkCore;

namespace Learning_Project.Repository
{
    public interface IRepository<TContext, TEntity> : IDisposable
        where TEntity : class
        where TContext : class
    {
        void Delete(TEntity entity);
        void DeleteCollection(List<TEntity> entityCollection);
        void DeleteWithNavigations(TEntity entity);
        Task<TEntity?> FindByIdAsync(object id);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void InsertCollection(List<TEntity> entityCollection);
        Task InsertCollectionAsync(List<TEntity> entityCollection);
        void InsertWithNavigations(TEntity entity);
        DbQuery<TEntity> Query();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Update(TEntity entity);
        void UpdateCollection(List<TEntity> entityCollection);
        void UpdateWithNavigations(TEntity entity);
    }
}