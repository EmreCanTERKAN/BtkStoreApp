using System.Linq.Expressions;

namespace Repositories.Contracts;
public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> FindAllAsync(bool trackChanges);
    Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
