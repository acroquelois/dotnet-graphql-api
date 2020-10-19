using System.Threading.Tasks;

namespace Skeleton.Internal.UnitOfWork
{
    public interface IUnitOfWork
    {
        TSet GetSet<TSet, TEntity>()
            where TSet : class
            where TEntity : class;

        Task<int> CommitAsync();

    }
}