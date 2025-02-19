using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore;
public abstract class RepositoryBase<T>(RepositoryContext context) : IRepositoryBase<T>
    where T : class
{
    public void Create(T entity) => context.Set<T>().Add(entity);

    public void Delete(T entity) => context.Set<T>().Remove(entity);


    public IQueryable<T> FindAll(bool trackChanges) =>
        trackChanges ? context.Set<T>() : context.Set<T>().AsNoTracking();


    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => trackChanges ? context.Set<T>().Where(expression) : context.Set<T>().Where(expression).AsNoTracking();


    public void Update(T entity) => context.Set<T>().Update(entity);

}
