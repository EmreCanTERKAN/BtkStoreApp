using Repositories.Contracts;

namespace Repositories.EFCore;
public class RepositoryManager(RepositoryContext context) : IRepositoryManager
{
    public IBookRepository Book => new BookRepository(context);

    public void Save()
    {
        context.SaveChanges();
    }
}
