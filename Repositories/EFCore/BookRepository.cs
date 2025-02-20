using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;
public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext context) : base(context) { }

    public async Task CreateOneBookAsync(Book book, CancellationToken cancellationToken = default)
        => await CreateAsync(book, cancellationToken);

    public async Task DeleteOneBookAsync(Book book, CancellationToken cancellationToken = default)
        => await DeleteAsync(book);

    public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges, CancellationToken cancellationToken = default)
        => await FindAllAsync(trackChanges, cancellationToken);

    public async Task<Book?> GetOneBookByIdAsync(int id, bool trackChanges, CancellationToken cancellationToken = default)
    {
        var result = await FindByConditionAsync(b => b.Id == id, trackChanges, cancellationToken);
        return result.FirstOrDefault(); // Eğer kitap yoksa null döndür
    }

    public async Task UpdateOneBookAsync(Book book, CancellationToken cancellationToken = default)
        => await UpdateAsync(book);
}

