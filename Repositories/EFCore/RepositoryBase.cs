using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore;
public abstract class RepositoryBase<T>(RepositoryContext context) : IRepositoryBase<T>
    where T : class
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        => await context.Set<T>().AddAsync(entity, cancellationToken);

    public Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> FindAllAsync(bool trackChanges, CancellationToken cancellationToken = default) =>
        trackChanges
            ? await context.Set<T>().ToListAsync(cancellationToken)
            : await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges, CancellationToken cancellationToken = default) =>
        trackChanges
            ? await context.Set<T>().Where(expression).ToListAsync(cancellationToken)
            : await context.Set<T>().Where(expression).AsNoTracking().ToListAsync(cancellationToken);

    public Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }
}

