using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore;
public abstract class RepositoryBase<T>(RepositoryContext context) : IRepositoryBase<T>
    where T : class
{
    public async Task CreateAsync(T entity) => await context.Set<T>().AddAsync(entity);

    public Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }


    public async Task<IEnumerable<T>> FindAllAsync(bool trackChanges) =>
        trackChanges ? await context.Set<T>().ToListAsync() : await context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
        trackChanges ? await context.Set<T>().Where(expression).ToListAsync() : await context.Set<T>().Where(expression).AsNoTracking().ToListAsync();


    public Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

}
