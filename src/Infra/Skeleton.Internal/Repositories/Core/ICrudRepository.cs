using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Skeleton.Domain.Models.Core;

namespace Skeleton.Internal.Repositories.Core
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new()
    {

        Task<TEntity> GetAsync(TKey id, bool tracking = false);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool track);
        
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null);

        void InsertAsync(TEntity entity);

        void InsertRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entities);
        
        void UpdateRange(IEnumerable<TEntity> entities);

        Task<bool> DeleteAsync(TKey id);

        Task DeleteRangeAsync(Expression<Func<TEntity, bool>> filter);
        
        IQueryable<TEntity> AsQueryable(bool track = false);

    }
}