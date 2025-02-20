using System.Linq.Expressions;

namespace Repositories.Contracts;
public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> FindAllAsync(bool trackChanges, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges, CancellationToken cancellationToken = default);
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
